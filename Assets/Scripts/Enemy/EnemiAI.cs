using System;
using System.Collections;
using UnityEngine;
using Pathfinding;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Seeker seeker;
    [SerializeField] private bool updateContinuesPath;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float nextWpDistance;
    
    private Path path;
    private Coroutine moveCoroutine;
    private bool reachDestination = false;
    private SpriteRenderer characterSr;
    
    private void Awake()
    {
        characterSr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;
    }

    void CalculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reachDestination || updateContinuesPath)) seeker.StartPath(transform.position, target, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCorotine());
    }

    private IEnumerator MoveToTargetCorotine()
    {
        int currentWp = 0;
        reachDestination = false;
        while (currentWp < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWp] - (Vector2)transform.position).normalized;
            Vector2 force = direction * (moveSpeed * Time.deltaTime);
            transform.position += (Vector3)force;
            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWp]);

            if (distance < nextWpDistance) currentWp++;
            
            if (force.x != 0)
            {
                if (force.x < 0)
                {
                    characterSr.transform.localScale = new Vector3(-1, 1, 0);
                }
                else
                {
                    characterSr.transform.localScale = new Vector3(1, 1, 0);
                }
            }

            yield return null;
        }

        reachDestination = true;
    }
    private Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<PlayerController>().transform.position;
        return playerPos;
    }
}