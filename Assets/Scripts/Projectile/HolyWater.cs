using UnityEngine;

public class HolyWater : Projectile
{
    private int level = 0;
    public HolyWater(GameObject projectilePrefab, Transform attackPoint, float attackCooldown = 3f, 
        float projectileSpeed = 8f, int projectileCount = 1, int projectileDamage = 10, bool isActive = false) 
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
            for (int i = 0; i < ProjectileCount; i++)
            {
                Transform findEnemy = FindNearestEnemy();
                if (findEnemy != null)
                {
                    Vector2 direction = (findEnemy.position - AttackPoint.position).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.Euler(0, 0, angle);
                    Object.Instantiate(ProjectilePrefab, AttackPoint.position, rotation);
                
                }
            }
            NextAttackTime = Time.time + AttackCooldown;
        }
    }
    
    public override void UpdateAbility()
    {
        level++;
        if (level == 1) IsActive = true;
        else if (level == 2)
        {
            ProjectileCount++;
            // up base area 
        }
        else if (level == 3)
        {
            ProjectileDamage += 10;
            // up time effect
        }
        else if (level == 4)
        {
            ProjectileCount ++;
        }
    }
}