using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;

public class Enimy_AI_1 : MonoBehaviour
{
    public float range = 30f;       // Радиус для поиска случайной точки
    private float chaseRange;   // Радиус обнаружения врагов
    public float attackRange = 2.5f;    // Радиус атаки
    public float stopRange = 2f;
    public float patrolSpeed = 0.5f;    // Скорость движения при патрулировании
    public float chaseSpeed = 2f;     // Скорость движения при преследовании
    private NavMeshAgent agent;         // Компонент NavMeshAgent
    private Transform player;           // Ссылка на игрока
    private Animator animator;           // Компонент Animator для управления анимациями
    public bool isChasing;             // Флаг, указывающий, преследует ли враг игрока
    private bool isPatrolling;           // Флаг для проверки патрулирования
    private Vector3 initialPosition;     // Начальная позиция врага
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Ищем объект игрока
        animator = GetComponent<Animator>(); // Получаем компонент Animator
        chaseRange = range / 2;
        isChasing = false;
        isPatrolling = false; // Начинаем не патрулируя
        initialPosition = transform.position; // Сохраняем начальную позицию

        StartCoroutine(IdleAndPatrol()); // Запускаем корутину для ожидания и патрулирования
    }

    private IEnumerator IdleAndPatrol()
    {
        animator.SetBool("Patroll", false); // Переход в состояние ожидания
        yield return new WaitForSeconds(3f); // Ждем 3 секунды
        agent.speed = patrolSpeed; // Устанавливаем скорость патрулирования
        isPatrolling = true; // Начинаем патрулирование
        animator.SetBool("Patroll", true);
        GoToRandomPatrolPoint(); // Устанавливаем первую цель патрулирования
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // Добавлено +1 к расстоянию

        if (isChasing)
        {
            agent.destination = player.position;

            if (distanceToPlayer > chaseRange)
            {
                isChasing = false;
                agent.speed = patrolSpeed; // Возвращаем скорость к патрулированию
                isPatrolling = true; // Возвращаемся к патрулированию
                GoToRandomPatrolPoint(); // Переход к случайной точке патрулирования
                animator.SetBool("Chase", false); // Сменить анимацию
                animator.SetBool("Patroll", true); // Переключиться на анимацию патрулирования
            }

            animator.SetBool("Chase", true); // Анимация преследования
            LookAtPlayer(); // Поворачиваемся к игроку

            if (distanceToPlayer <= attackRange) // Если враг в радиусе атаки
            {

                Attack(); // Выполнение атаки

            }

            else
            {
                if (distanceToPlayer > stopRange)
                {
                    agent.SetDestination(player.position);
                }
                else
                {
                    agent.ResetPath();
                }
            }
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 1f)
            {
                if (isPatrolling)
                {
                    GoToRandomPatrolPoint(); // Переход к случайной точке патрулирования
                    animator.SetBool("Patroll", true); // Сменить анимацию на патрулирование
                }
            }

            if (distanceToPlayer <= chaseRange)
            {
                isChasing = true;
                agent.speed = chaseSpeed; // Увеличиваем скорость при преследовании
                isPatrolling = false; // Прекращаем патрулирование
                animator.SetBool("Chase", true); // Начинаем анимацию преследования
            }
            else
            {
                animator.SetBool("Chase", false); // Возврат к патрулированию
            }
        }
    }
    void GoToRandomPatrolPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection.y = 0; // Убедитесь, что высота равна 0 (или установите нужную вам высоту)
        Vector3 randomPosition = initialPosition + randomDirection; // Расчет случайной позиции от начальной точки
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, range, NavMesh.AllAreas))
        {
            float distanceFromInitial = Vector3.Distance(initialPosition, hit.position); // Расстояние от начальной точки
            if (distanceFromInitial <= range) // Проверяем, чтобы не было превышения радиуса
            {
                agent.destination = hit.position; // Устанавливаем новую случайную цель
            }
        }
    }

    void LookAtPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer); // Вычисляем поворот
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // Плавный поворот
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
}