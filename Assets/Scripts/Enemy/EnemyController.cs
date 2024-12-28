using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    
    [SerializeField] private int health = 50;
    [SerializeField] private int damage = 10;
    [SerializeField] private float dropRate = 0.67f;
    [SerializeField] private GameObject expPrefab;
    [SerializeField] private float knockbackForce;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private PlayerController playerControllerScript;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    { 
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerControllerScript = other.GetComponent<PlayerController>();
            if (playerControllerScript != null)
            {
                InvokeRepeating("DamagePlayer", 0, 2f);
            }
        }
        if(other.gameObject.CompareTag("Bullet"))
        {
            Vector2 difference = (transform.position - other.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            rb.AddForce(force, ForceMode2D.Impulse); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerControllerScript != null)
            {
                playerControllerScript = null;
                CancelInvoke("DamagePlayer");
            }
        }
    }

    private void DamagePlayer()
    {
        playerControllerScript.TakeDamage(damage);
    }
    
    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            if (Random.Range(0f, 1f) <= dropRate) Instantiate(expPrefab, transform.position, Quaternion.identity);
            FindObjectOfType<SetTextUI>().UpdateKillUI();
            Destroy(gameObject);
        }
    }
    
}
