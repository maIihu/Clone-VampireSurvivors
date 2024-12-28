using Unity.VisualScripting;
using UnityEngine;

public class Sword : Projectile
{
    public Sword(GameObject projectilePrefab, Transform attackPoint, float attackCooldown = 1f, 
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
            Quaternion tempRotation;
            
            float zRotation = AttackPoint.rotation.eulerAngles.z;

            if (zRotation > 90 && zRotation < 270)
                tempRotation = Quaternion.Euler(new Vector3(0, 0, 180)); 
            else
                tempRotation = Quaternion.identity; 
            
            Object.Instantiate(ProjectilePrefab, AttackPoint.position, tempRotation);
            
            NextAttackTime = Time.time + AttackCooldown;
        }
    }
    
    public override void UpdateAbility()
    {
        if (IsActive == false) IsActive = true;
        else
        {
            ProjectileDamage += 10;
        }
    }
}