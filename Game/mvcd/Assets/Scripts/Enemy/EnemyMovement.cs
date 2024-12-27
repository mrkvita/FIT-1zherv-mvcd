using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public Animator animator; 
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private PlayerDetectionController playerDetectionController;
    private Vector3 targetDirection;
    bool facingLeft = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerDetectionController = FindObjectOfType<PlayerDetectionController>();
        
    }
    void Update()
    {
       UpdateTargetDir();
    }

    private void FixedUpdate()
    {
       Flip();
       SetSpeed();
        
       animator.SetFloat("Speed", targetDirection.sqrMagnitude);
    }

    private void UpdateTargetDir()
    {
        if (playerDetectionController.playerDetected)
        {
            targetDirection = playerDetectionController.directionToPlayer;
        }
        else
        {
            targetDirection = Vector3.zero;
        }
    }

    private void Flip()
    {
        if (facingLeft)
        {
            if (targetDirection.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180f, 0);
                facingLeft = !facingLeft;
            }
        }
        else
        {
            if (targetDirection.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                facingLeft = !facingLeft;
            }
        }
    }

    private void SetSpeed()
    {
        if (targetDirection == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
           rb.MovePosition((transform.position + targetDirection * moveSpeed * Time.fixedDeltaTime));
        }
    }
}
