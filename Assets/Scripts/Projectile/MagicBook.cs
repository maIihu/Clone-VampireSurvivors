using UnityEngine;


public class MagicBook : Projectile
{
    private int level = 0;
    
    public MagicBook(GameObject projectilePrefab, Transform attackPoint, float attackCooldown = 4f, 
        float projectileSpeed = 100f, int projectileCount = 1, int projectileDamage = 10, bool isActive = false) 
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
            float angleOffset = 360f / ProjectileCount;
            float distanceFromAttackPoint = 2f; // khoảng cách từ AttackPoint đến vị trí projectiles

            for (int i = 0; i < ProjectileCount; i++)
            {
                // Tính toán góc quay
                float currentAngle = angleOffset * i;

                // Tính toán vị trí dựa trên khoảng cách và góc
                Vector3 offset = new Vector3(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * distanceFromAttackPoint;
                Vector3 projectilePosition = AttackPoint.position + offset;

                // Instantiate projectile tại vị trí tính toán
                var projectileInstance = Object.Instantiate(ProjectilePrefab, projectilePosition, Quaternion.identity);

                // Gán cho projectile một script để nó quay tròn xung quanh AttackPoint
                projectileInstance.GetComponent<MagicBookManager>().StartRotatingAround(AttackPoint, distanceFromAttackPoint, currentAngle);
            }

            NextAttackTime = Time.time + AttackCooldown;
        }
    }
    
    
    public override void UpdateAbility()
    {
        level++;
        if (level == 1) IsActive = true;
        else if (level == 2) ProjectileCount += 1;
        else if (level == 3) ProjectileSpeed += ProjectileSpeed * 30/100;
        else if (level == 4) ProjectileDamage += 10;
    }
}