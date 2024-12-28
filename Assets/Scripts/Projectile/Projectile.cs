using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Projectile
{
    protected GameObject ProjectilePrefab { get; }
    public Transform AttackPoint { get; }
    public float AttackCooldown { get; set; }
    public float ProjectileSpeed { get;  set; }
    public int ProjectileDamage { get;  set; }
    public bool IsActive { get; set; }
    public int ProjectileCount { get; set; }
    protected float NextAttackTime;
    
    protected Projectile(GameObject projectilePrefab, Transform attackPoint, 
        float attackCooldown, float projectileSpeed, int projectileDamage, bool isActive)
    {
        this.ProjectilePrefab = projectilePrefab;
        this.AttackPoint = attackPoint;
        this.AttackCooldown = attackCooldown;
        this.ProjectileSpeed = projectileSpeed;
        this.ProjectileDamage = projectileDamage;
        this.IsActive = isActive;
        NextAttackTime = 0;
    }

    public abstract void Throw();

    public abstract void UpdateAbility();
    
    protected Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(AttackPoint.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }
    
    protected Transform FindRandomEnemy()
    {
        List<Transform> enemies = new List<Transform>();
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemyObjects)
        {
            enemies.Add(enemyObject.transform);
        }

        if (enemies.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, enemies.Count);
        return enemies[randomIndex];
    }
}