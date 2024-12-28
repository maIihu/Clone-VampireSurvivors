using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmProjectile : MonoBehaviour
{
    [SerializeField] private int damage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    
    }
}
