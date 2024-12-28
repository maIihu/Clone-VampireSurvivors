using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    private Knife knife;
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
        knife = new Knife(projectilePrefab, attackPoint);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(knife.ProjectileDamage);
                DamagePopup.Create(enemyController.transform.position, knife.ProjectileDamage);
            }
            Destroy(gameObject);
        }
    }
}