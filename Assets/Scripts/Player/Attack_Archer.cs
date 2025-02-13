using UnityEngine;

public class Attack_Archer : MonoBehaviour
{
    public GameObject Arrow_Prefab;
    public AudioClip audioArrow;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;
    public Transform spawnPoint;
    private GameObject enemy;
    private int fireindex = 0;

    private void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioArrow;
        hitAudioSource.volume = volume;
    }

    public void Fire()
    {
        if (spawnPoint == null)
        {
            return;
        }
        GameObject arrow = Instantiate(Arrow_Prefab, spawnPoint.position, spawnPoint.rotation);
        const int size = 1;
        arrow.transform.localScale *= size;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 launchDirection;
            rb.mass = Mathf.Pow(size, 2);
            if (enemy != null)
            {
                Vector3 targetPosition = enemy.transform.position;
                targetPosition.y += 0.5f;

                // Вычисляем направление к врагу
                launchDirection = (targetPosition - spawnPoint.position).normalized;
            }
            else
            {
                // Если врага нет, стрела летит вперед
                launchDirection = spawnPoint.forward;
            }
            rb.AddForce(launchDirection * 20f, ForceMode.Impulse);
        }
    }
    public void OnAttackAnimationComplete()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                enemy = hit.collider.gameObject; // Сохраняем врага
                Debug.Log("Enemy");
            }
        }
        ExecuteFireType();
        hitAudioSource.Play();
    }

    public void FireMultipleArrows()
    {
        StartCoroutine(FireArrowsCoroutine(5, 0.1f));
    }

    private System.Collections.IEnumerator FireArrowsCoroutine(int numberOfArrows, float interval)
    {
        for (int i = 0; i < numberOfArrows; i++)
        {
            Fire();
            hitAudioSource.Play();
            yield return new WaitForSeconds(interval);
        }
    }

    public void FireInCircle()
    {
        float angleStep = 360f / 8; // Угол между стрелами
        for (int i = 0; i < 8; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, angle, 0); // Поворачиваем стрелу
            GameObject arrow = Instantiate(Arrow_Prefab, spawnPoint.position, rotation);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 launchDirection = rotation * Vector3.forward; // Направление по кругу
                rb.AddForce(launchDirection * 20f, ForceMode.Impulse);
            }
        }
    }

    public void ExecuteFireType()
    {
        switch (fireindex)
        {
            case 0:
                Fire(); // Одиночный выстрел
                break;
            case 1:
                FireMultipleArrows(); // 5 выстрелов каждые 0.1 секунды
                break;
            case 2:
                FireInCircle(); // 8 стрел в круге
                break;
            default:
                Debug.LogWarning("Неверный тип стрельбы");
                break;
        }
    }

    public void ChooseFireType(int fireType)
    {
        fireindex = fireType; // Устанавливаем только индекс типа стрельбы
        Debug.Log("Тип стрельбы установлен: " + fireindex);
    }
}

