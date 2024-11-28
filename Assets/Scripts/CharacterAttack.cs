using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public enum CharacterClass { Warrior, Archer, Mage }
    public CharacterClass characterClass;
    
    // Для Воина
    public float attackDamage = 10f;

    // Для Лучника
    public GameObject arrowPrefab; // Префаб стрелы
    public Transform arrowSpawnPoint; // Точка появления стрелы
    public float arrowSpeed = 20f; // Скорость стрелы

    // Для Мага
    public GameObject magicPrefab; // Префаб магического снаряда
    public Transform magicSpawnPoint; // Точка появления магического снаряда
    public float magicSpeed = 15f; // Скорость магического снаряда

    public void Attack()
    {

        switch (characterClass)
        {
            case CharacterClass.Warrior:
                AttackWithWarrior();
                break;
            case CharacterClass.Archer:
                AttackWithArcher();
                break;
            case CharacterClass.Mage:
                AttackWithMage();
                break;
        }
    }

    private void AttackWithWarrior()
    {
        Debug.Log("Воин атакует! Урон: " + attackDamage);
        // Логика нанесения урона врагу (можно добавить логику, если у вас есть коллайдеры для врагов)
        // Например, можно использовать OnTriggerEnter для коллайдеров атаки
    }

    private void AttackWithArcher()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = arrowSpawnPoint.forward * arrowSpeed; // Запуск стрелы вперед
        }
        Debug.Log("Лучник стреляет!");
    }

    private void AttackWithMage()
    {
        GameObject spell = Instantiate(magicPrefab, magicSpawnPoint.position, magicSpawnPoint.rotation);
        Rigidbody rb = spell.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = magicSpawnPoint.forward * magicSpeed; // Запуск магического снаряда вперед
        }
        Debug.Log("Маг использует заклинание!");
    }
}