using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePos;
    
    public bool facingRight = true;
    
    // Get the rb component
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Input
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // Movement
    private void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Move();
        Flip(); 
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * movement.normalized * Time.fixedDeltaTime );
    }

    private void Flip()
    {
       // vector from the character to mouse pos  
        Vector2 lookDir = mousePos - rb.position;
       // get the angle of the vector  
       float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        if (facingRight)
        {
            // checking for the correct quadrants in which to flip
            if ( angle > 90 || angle < -90)
            {
                transform.localRotation = Quaternion.Euler(0f, 180.0f, 0.0f);
                facingRight = !facingRight;
            }
        }
        else
        {
            if ( angle > -90 &&  angle < 90)
            {
                transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                facingRight = !facingRight;
            }
        }
    }
}
