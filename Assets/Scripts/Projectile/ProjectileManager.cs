using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileManager : MonoBehaviour
{
    public PlayerStats playerStats;
    
    public Transform attackPoint;

    
    public GameObject fireballPrefab;
    public GameObject holyWaterPrefab;
    public GameObject crossPrefab;
    public GameObject swordPrefab;
    public GameObject shieldFirePrefab;
    public GameObject knifePrefab;
    public GameObject magicBookPrefab;
    
    private List<Projectile> projectiles = new List<Projectile>();
    
    private Fireball fireball;
    private HolyWater holyWater;
    private Cross cross;
    private Sword sword;
    private ShieldFire shieldFire;
    private Knife knife;
    private MagicBook magicBook;
    
    private UpgradeManager upgradeManager;

    private void Awake()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();
        playerStats = FindObjectOfType<GameManager>().playerStats;
    }


    private void Start()
    {
        Init();
        AddProjectile();
        ProjectilePowerUp();
    }
    
    private void Init()
    {
        fireball = new Fireball(fireballPrefab, attackPoint);
        holyWater = new HolyWater(holyWaterPrefab, attackPoint); 
        cross = new Cross(crossPrefab, attackPoint);
        sword = new Sword(swordPrefab, attackPoint);
        shieldFire = new ShieldFire(shieldFirePrefab, attackPoint);
        knife = new Knife(knifePrefab, attackPoint);
        magicBook = new MagicBook(magicBookPrefab, attackPoint);
    }

    private void AddProjectile()
    {
        projectiles.Add(fireball);
        projectiles.Add(holyWater);
        projectiles.Add(cross);
        projectiles.Add(sword);
        projectiles.Add(shieldFire);
        projectiles.Add(knife);
        projectiles.Add(magicBook);
    }
    private void Update()
    {
        RotateAttackPoint();
        
        UpdateAbilities();
        
        foreach (var projectile in projectiles)
        {
            projectile.Throw();
        }
    }

    private void ProjectilePowerUp()
    {
        fireball.ProjectileDamage += playerStats.damageBonus;
        fireball.ProjectileCount += playerStats.amountBonus;
        fireball.AttackCooldown += fireball.AttackCooldown * playerStats.cooldownBonus;
        fireball.ProjectileSpeed += fireball.ProjectileSpeed * playerStats.speedBonus;
        
        cross.ProjectileCount += playerStats.amountBonus;
        cross.AttackCooldown += cross.AttackCooldown * playerStats.cooldownBonus;
        cross.ProjectileSpeed += cross.ProjectileSpeed * playerStats.speedBonus;
        cross.ProjectileDamage += playerStats.damageBonus;
        
        holyWater.ProjectileDamage += playerStats.damageBonus;
        holyWater.ProjectileCount += playerStats.amountBonus;
        holyWater.AttackCooldown += holyWater.AttackCooldown * playerStats.cooldownBonus;
        holyWater.ProjectileSpeed += holyWater.ProjectileSpeed * playerStats.speedBonus;
        
        knife.ProjectileDamage += playerStats.damageBonus;
        knife.ProjectileCount += playerStats.amountBonus;
        knife.AttackCooldown += holyWater.AttackCooldown * playerStats.cooldownBonus;
        knife.ProjectileSpeed += holyWater.ProjectileSpeed * playerStats.speedBonus;
        
        magicBook.ProjectileDamage += playerStats.damageBonus;
        magicBook.ProjectileCount += playerStats.amountBonus;
        magicBook.AttackCooldown += holyWater.AttackCooldown * playerStats.cooldownBonus;
        magicBook.ProjectileSpeed += holyWater.ProjectileSpeed * playerStats.speedBonus;
    }
    
    private void UpdateAbilities()
    {
        if (upgradeManager.isUpdateDamage)
        {
            fireball.ProjectileDamage++;
            holyWater.ProjectileDamage++;
            cross.ProjectileDamage++;
            sword.ProjectileDamage++;
            shieldFire.ProjectileDamage++;
            knife.ProjectileDamage++;
            
            upgradeManager.isUpdateDamage = false;
        }
        if(upgradeManager.isUpdateFireball)
        {
            fireball.UpdateAbility();
            upgradeManager.isUpdateFireball = false;
        }
        
        if(upgradeManager.isUpdateHolyWater)
        {
            holyWater.UpdateAbility();
            upgradeManager.isUpdateHolyWater = false;
        }
        
        if(upgradeManager.isUpdateCross)
        {
            cross.UpdateAbility();
            upgradeManager.isUpdateCross = false;
        }
        if(upgradeManager.isUpdateSword)
        {
            sword.UpdateAbility();
            upgradeManager.isUpdateSword = false;
        }

        if (upgradeManager.isUpdateMagicBook)
        {
            magicBook.UpdateAbility();
            upgradeManager.isUpdateMagicBook = false;
        }

        if (upgradeManager.isUpdateKnife)
        {
            knife.UpdateAbility();
            upgradeManager.isUpdateKnife = false;
        }
    }
    
    private void RotateAttackPoint()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 direction = (mousePosition - attackPoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackPoint.rotation = Quaternion.Euler(0, 0, angle);
    }
    
}
