using UnityEngine;

public class Cross : Projectile
{
    private int level = 0;
    
    public Cross(GameObject projectilePrefab, Transform attackPoint, float attackCooldown = 2f, 
        float projectileSpeed = 10f, int projectileCount = 1, int projectileDamage = 10, bool isActive = false) 
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
                Transform findEnemy = FindRandomEnemy();
                if (findEnemy != null)
                {
                    Vector2 direction = (findEnemy.position - AttackPoint.position).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.Euler(0, 0, angle);
                    GameObject projectile = Object.Instantiate(ProjectilePrefab, AttackPoint.position, rotation);
                     Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                    projectileRb.velocity = rotation * Vector2.right * ProjectileSpeed;
                
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
        else if (level == 3) ProjectileSpeed += ProjectileSpeed * 25/100;
        else if (level == 4) ProjectileCount += 1;
    }
}