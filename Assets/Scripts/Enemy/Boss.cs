using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform player; 
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float attackCoolDown = 1f;
    
    private float nextTimeAttack = 0f;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        GameObject boss = GameObject.FindWithTag("Boss");
        attackPoint = boss.transform.Find("AttackPoint");
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= 20f && Time.time >= nextTimeAttack)
        {
            ani.SetTrigger("Attack1");
            ThrowArmProjectile();
            nextTimeAttack = Time.time + attackCoolDown;
        }
    }

    private void ThrowArmProjectile()
    {
        GameObject pjTemp = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        Rigidbody2D rb = pjTemp.GetComponent<Rigidbody2D>();
        
        Vector2 direction = (player.position - attackPoint.position).normalized;
        
        rb.AddForce(direction * projectileSpeed, ForceMode2D.Impulse);

        // Rotate the projectile to face the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        pjTemp.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}