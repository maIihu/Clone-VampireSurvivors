using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float stopDistance = 8f; 
    [SerializeField] private GameObject waterAreaPrefab; 

    private Vector3 targetPosition;
    private bool moving = true;
    
    void Start()
    {
        targetPosition = transform.position + transform.right * stopDistance;
    }
    
    void Update()
    {
        if (moving)
        {
            float step = moveSpeed * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                moving = false;
                CreateWaterArea();
            }
        }
    }
    
    void CreateWaterArea()
    {
        Instantiate(waterAreaPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }
}