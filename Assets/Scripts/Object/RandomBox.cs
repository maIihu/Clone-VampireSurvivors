using UnityEngine;
using System.Collections;

public class RandomPrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnInterval = 30f;

    void Start()
    {
        StartCoroutine(SpawnPrefabRoutine());
    }

    IEnumerator SpawnPrefabRoutine()
    {
        while (true)
        {
            SpawnRandomPrefab();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomPrefab()
    {
        float x = Random.Range(-201/2f, 201/2f); 
        float y = Random.Range(-201/2f, 201/2f); 
        Vector3 spawnPosition = new Vector3(x, y, 0);
        
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}