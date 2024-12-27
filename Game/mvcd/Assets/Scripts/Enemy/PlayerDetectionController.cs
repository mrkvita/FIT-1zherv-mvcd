using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionController : MonoBehaviour
{
    public bool playerDetected { get; private set; }
    public Vector2 directionToPlayer;

    [SerializeField] private float detectionRange;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Vector3 enemyToPlayer = playerTransform.position - transform.position;
        float distanceToPlayer = enemyToPlayer.magnitude; 
        directionToPlayer = enemyToPlayer.normalized;
        if (distanceToPlayer < detectionRange)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }
}
