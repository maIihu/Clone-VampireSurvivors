using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] private int projectileDamage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(projectileDamage);
                DamagePopup.Create(enemyController.transform.position, projectileDamage);
            }
            Destroy(gameObject);
        }
    }
}
