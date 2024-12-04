using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class DynamicEnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Массив префабов врагов
    public int enemyCount = 6; // Исходное количество врагов
    public float spawnRadius = 20f; // Радиус спавна
    public float spawnInterval = 5f; // Интервал спавна в секундах
    public Transform spawnPoint; // Точка спауна

    private List<GameObject> enemies; // Список активных врагов

    void Start()
    {
        enemies = new List<GameObject>();
        StartCoroutine(SpawnEnemiesCoroutine());
    }
private void FixedUpdate()
    {
        CheckAndSpawnEnemies();
        if (enemies.Count == 0)
        {
            StartCoroutine(SpawnEnemiesCoroutine());
        }
    }
    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (enemies.Count < enemyCount) // Пока врагов меньше исходного количества
        {
            SpawnEnemy(); // Спавн одного врага

            // Ожидание заданного интервала перед следующим спавном
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0; // Установка Y в 0 для спавна на плоскости

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, 1.0f, NavMesh.AllAreas))
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], hit.position, Quaternion.identity);
            enemies.Add(enemy); // Добавление врага в список
        }
    }

    void CheckAndSpawnEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null) // Проверка на уничтоженного врага
            {
                enemies.RemoveAt(i); // Удаление уничтоженного врага из списка
            }
        }
    }
}