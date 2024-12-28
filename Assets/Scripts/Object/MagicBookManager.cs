using System;
using UnityEngine;

public class MagicBookManager : MonoBehaviour
{
    private MagicBook magicBook;
    private Transform attackPoint;
    private GameObject projectilePrefab;
    private float radius;
    private float angle;
    
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        attackPoint = player.transform.Find("AttackPoint");
        projectilePrefab = GetComponent<GameObject>();
    }

    private void Start()
    {
        magicBook = new MagicBook(projectilePrefab, attackPoint);
    }

    public void StartRotatingAround(Transform attackPoint, float radius, float initialAngle)
    {
        this.attackPoint = attackPoint;
        this.radius = radius;
        this.angle = initialAngle;
    }

    private void Update()
    {
        if (attackPoint != null)
        {
            // Cập nhật góc quay theo thời gian
            angle += magicBook.ProjectileSpeed * Time.deltaTime;

            // Tính toán vị trí mới dựa trên góc quay và bán kính
            float radian = angle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian)) * radius;
            transform.position = attackPoint.position + offset;

            // Cập nhật hướng của projectile
            float angleToCenter = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angleToCenter);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(magicBook.ProjectileDamage);
                DamagePopup.Create(enemyController.transform.position, magicBook.ProjectileDamage);
            }
        }
    }
}