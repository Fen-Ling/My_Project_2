using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int enemyCount = 6;
    public float spawnRadius = 20f;
    public float spawnInterval = 1.5f;
    public Transform spawnPoint;
    private List<GameObject> enemies;
    public Transform player;

    void Start()
    {
        enemies = new List<GameObject>();
    }
    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector3.Distance(transform.position, player.position) <= 100)
        {
            CheckAndSpawnEnemies();
            if (enemies.Count == 0)
            {
                StartCoroutine(SpawnEnemiesCoroutine());
            }

        }
        else
        {
            RemoveAllEnemies();
        }

    }
    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (enemies.Count < enemyCount)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, 1.0f, NavMesh.AllAreas))
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], hit.position, Quaternion.identity);
            enemies.Add(enemy);
        }
    }

    void CheckAndSpawnEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
    }

    void RemoveAllEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            Destroy(enemies[i]);
            enemies.RemoveAt(i);
        }
    }
}