using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFireManager : MonoBehaviour
{
    private ShieldFire shieldFire;
    private Transform attackPoint;
    private GameObject fireballPrefab;
    [SerializeField] private float damageInterval = 0.5f; // khoảng thời gian thiệt hại 
    private float nextDamageTime = 0f;
    
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        attackPoint = player.transform.Find("AttackPoint");
        fireballPrefab = GetComponent<GameObject>();
        shieldFire = new ShieldFire(fireballPrefab, attackPoint);
    }

    private void Update()
    {
        transform.position = attackPoint.position;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && Time.time >= nextDamageTime)
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(shieldFire.ProjectileDamage);
                DamagePopup.Create(enemyController.transform.position, shieldFire.ProjectileDamage);
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}
