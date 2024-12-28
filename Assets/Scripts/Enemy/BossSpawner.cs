using System.Collections;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnBossAfterDelay(60f));
    }

    private IEnumerator SpawnBossAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}