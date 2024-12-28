using UnityEngine;

public class ShieldFire : Projectile
{
    public ShieldFire(GameObject projectilePrefab, Transform attackPoint, float attackCooldown = 4f, 
        float projectileSpeed = 0f, int projectileCount = 1, int projectileDamage = 10, bool isActive = false) 
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
            Object.Instantiate(ProjectilePrefab, AttackPoint.position, Quaternion.identity);
            NextAttackTime = Time.time + AttackCooldown;
        }
    }


    public override void UpdateAbility()
    {
        if (IsActive == false) IsActive = true;
        else
        {
            ProjectileDamage += 10;
            ProjectileCount++;
        }
    }
}
