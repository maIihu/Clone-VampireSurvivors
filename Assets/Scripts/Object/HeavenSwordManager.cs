using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenSwordManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(10);
                
            }
            //Destroy(gameObject);
        }
    }
}
