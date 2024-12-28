using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAreaManager : MonoBehaviour
{
    
    [SerializeField] private float damageInterval = 0.2f;
    private float nextDamageTime = 0f;

    private HolyWater holyWater;
    private Transform attackPoint;
    private GameObject projectilePrefab;

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        attackPoint = player.transform.Find("AttackPoint");
        projectilePrefab = GetComponent<GameObject>();
    }

    private void Start()
    {
        holyWater = new HolyWater(projectilePrefab, attackPoint);
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Enemy") || other.CompareTag("Boss")) && Time.time >= nextDamageTime)
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(holyWater.ProjectileDamage);
                DamagePopup.Create(enemyController.transform.position, holyWater.ProjectileDamage);
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}
