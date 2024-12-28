using System;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class Fireball : Projectile
{
    private int level = 0;
    public Fireball(GameObject projectilePrefab, Transform attackPoint, float attackCooldown = 3f, 
        float projectileSpeed = 8f, int projectileCount = 2, int projectileDamage = 20, bool isActive = false) 
        : base(projectilePrefab, attackPoint, attackCooldown, projectileSpeed, projectileDamage, isActive)
    {
        this.ProjectileCount = projectileCount;
        this.ProjectileSpeed = projectileSpeed;
        this.ProjectileDamage = projectileDamage;
        this.IsActive = isActive;
    }

    public override void Throw()
    {
        if (IsActive && Time.time >= NextAttackTime)
        {
            Transform findEnemy = FindRandomEnemy();
            if (findEnemy != null)
            {
                Vector2 direction = (findEnemy.position - AttackPoint.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                for (int i = 0; i <= ProjectileCount; i++)
                {
                    float angleOffset = 10 * i;
                    Quaternion rotation = Quaternion.Euler(0, 0, angle + angleOffset);
                    GameObject projectile = Object.Instantiate(ProjectilePrefab, AttackPoint.position, rotation);
                    Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                    
                    projectileRb.velocity =  rotation * Vector2.right* ProjectileSpeed;
                }
            }
            NextAttackTime = Time.time + AttackCooldown;
        }
    }


    public override void UpdateAbility()
    {
        level++;
        if (level == 1) IsActive = true;
        else if (level == 2) ProjectileDamage += 10;
        else if (level == 3)
        {
            ProjectileDamage += 10;
            ProjectileSpeed *= (float)0.2;
        }
        else if (level == 4) ProjectileCount += 10;
    }
}
