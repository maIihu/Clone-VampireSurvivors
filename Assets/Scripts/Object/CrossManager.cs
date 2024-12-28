using UnityEngine;

public class CrossManager : MonoBehaviour
{
    [SerializeField] private float distance = 8f; 
    [SerializeField] private float travelTime = 2f; 
    private Vector2 startPoint;
    private Vector2 endPoint;
    private float elapsedTime = 0f;
    private bool returning = false;

    private Cross cross;
    private Transform attackPoint;
    private GameObject projectilePrefab;
    
    [SerializeField] private float rotationSpeed = 360f; 
    
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        attackPoint = player.transform.Find("AttackPoint");
        projectilePrefab = GetComponent<GameObject>();
    }
    
    private void Start()
    {
        cross = new Cross(projectilePrefab, attackPoint);
        
        startPoint = transform.position;
        endPoint = startPoint + (Vector2)transform.up * distance; 
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
        elapsedTime += Time.deltaTime;

        if (!returning)
        {
            transform.position = Vector2.Lerp(startPoint, endPoint, elapsedTime / travelTime);
            if (elapsedTime >= travelTime)
            {
                elapsedTime = 0f;
                returning = true;
            }
        }
        else
        {
            transform.position = Vector2.Lerp(endPoint, startPoint, elapsedTime / travelTime);
            if (elapsedTime >= travelTime)
            {
                Destroy(gameObject);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")|| other.CompareTag("Boss"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(cross.ProjectileDamage);
                DamagePopup.Create(enemyController.transform.position, cross.ProjectileDamage);
            }
        }
    }
    
}