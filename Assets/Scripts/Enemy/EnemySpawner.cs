using System;
using System.Collections;
using UnityEngine;
using Random=UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    
    [SerializeField] private Transform player; 
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float spawnRadiusMax = 20f;
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemies = 30;
    [SerializeField] private float radius = 14f;
    [SerializeField] private float spawnTime = 60f;
    
    private void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(SpawnerAroundCircle());
    }

    private IEnumerator SpawnerAroundCircle()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnTime);
        while (canSpawn)
        {
            yield return wait;
            for (int i = 0; i < numberOfEnemies; i++)
            {
                float angle = i * Mathf.PI * 2 / numberOfEnemies;
                Vector2 spawnPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
                Vector2 finalPosition = (Vector2)player.position + spawnPosition;
                Instantiate(enemyPrefab, finalPosition, Quaternion.identity);
            }
        }
    }
    
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length - 1);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            Vector3 spawnPosition = GetRandomPositionOutsideRadius(player.position, spawnRadius, spawnRadiusMax);
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        }
    }
    Vector3 GetRandomPositionOutsideRadius(Vector3 center, float minRadius, float maxRadius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float radius = Random.Range(minRadius, maxRadius);
        Vector3 spawnPosition = new Vector3(
            center.x + radius * Mathf.Cos(angle),
            center.y + radius * Mathf.Sin(angle),
            center.z
        );
        return spawnPosition;
    }
}
