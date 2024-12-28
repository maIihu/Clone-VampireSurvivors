using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator ani;

    private AudioManager audioManager;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private int armor;
    [SerializeField] private int recovery;
    [SerializeField] private int growth;
    [SerializeField] private float luck;
    
    [SerializeField] private int level = 1;
    
    // biến xử lý máu
    private int maxHealth;
    public int currentHealth;
    [SerializeField] private BarControl healthBarControl;
    
    // biến xử lý kinh nghiệm
    private int maxExp = 10;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private BarControl expBarControl;
    [SerializeField] private bool levelUp;

    // biến xử lý tiền
    [SerializeField] private int currentGold = 0;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float nextAttackTime = 0f;
    [SerializeField] private float attackCooldown = 1f;

    public bool isDead = false;
    
    // xử lý hồi máu
    private float requiredTimeInZone = 5f; 
    private Coroutine healingCoroutine;
    private bool canHeal = true;

    private SetTextUI setTextUI;
    
    public Vector2 MoveInput
    {
        get => moveInput;
        set => moveInput = value;
    }
    public bool CanHeal
    {
        get => canHeal;
        set => canHeal = value;
    }

    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    public bool LevelUp
    {
        get => levelUp;
        set => levelUp = value;
    }

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    public int Armor
    {
        get => armor;
        set => armor = value;
    }

    public int Growth
    {
        get => growth;
        set => growth = value;
    }

    public int Recovery
    {
        get => recovery;
        set => recovery = value;
    }

    public float Luck
    {
        get => luck;
        set => luck = value;
    }
    private void Awake()
    {
        playerStats = FindObjectOfType<GameManager>().playerStats;
        setTextUI = FindObjectOfType<SetTextUI>();
        
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
        maxHealth = playerStats.maxHealth;
        moveSpeed = playerStats.moveSpeed;
        armor = playerStats.armor;
        growth = playerStats.growth;
        luck = playerStats.luck;
        
        currentHealth = maxHealth;
    }

    private void Start()
    {
    }

    private void Update()
    {
        HandleInput();   
        Throw();
        UpdateAnimator();
        UpdateHealthAndExpBar();
        PlayerRecovery();
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * (moveSpeed * Time.fixedDeltaTime));
    }
    
    private void HandleInput()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        if (moveInput.x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    
    private void UpdateAnimator()
    {
        bool isWalking = moveInput.x != 0 || moveInput.y != 0;
        ani.SetBool("isWalking", isWalking);
        
    }
    private void Throw()
    {
        if (Time.time >= nextAttackTime)
        {
            ani.SetTrigger("isAttacking");
            
            StartCoroutine(ThrowProjectileWithDelay(0.4f));
            
            audioManager.PlaySfx(audioManager.throwArrow);
            
            nextAttackTime = Time.time + attackCooldown;
        }
    }


    private IEnumerator ThrowProjectileWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        
                                                                                                                      
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = attackPoint.transform.right * projectileSpeed;
        
    }
    private void UpdateHealthAndExpBar()
    {
        if (currentExp >= maxExp) 
        { 
            levelUp = true; 
            currentExp -= maxExp;
            maxExp += 5;
            level++;
            setTextUI.UpdateLevelText(level);
        }
        else levelUp = false;
        healthBarControl.UpdateBar(currentHealth, maxHealth); 
        expBarControl.UpdateBar(currentExp, maxExp);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exp"))
        {
            currentExp += 3;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            currentGold += 5 * growth;
            setTextUI.UpdateGoldUI(currentGold);
            playerStats.gold += currentGold;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("HealingZone"))
        {
            if (healingCoroutine == null && canHeal)
            {
                healingCoroutine = StartCoroutine(HealAfterTime());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HealingZone") && canHeal)
        {
            if (healingCoroutine != null)
            {
                StopCoroutine(healingCoroutine);
                healingCoroutine = null;
            }
        }
    }
    
    private IEnumerator HealAfterTime()
    {
        yield return new WaitForSeconds(requiredTimeInZone);
        if (currentHealth < maxHealth) currentHealth = maxHealth;
        canHeal = false; 
        StartCoroutine(CooldownHealingZone());
        healingCoroutine = null; 
    }
    private IEnumerator CooldownHealingZone()
    {
       // Debug.Log("Cooldown Started");
        yield return new WaitForSeconds(30f);
        canHeal = true; 
       // Debug.Log("Cooldown Ended, Ready to Heal Again");
    }
    private void PlayerRecovery()
    {
        if (currentHealth < maxHealth) currentHealth += recovery;
    }
    
    public void TakeDamage(int value)
    {
        currentHealth -= (value - armor);
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }
    
}