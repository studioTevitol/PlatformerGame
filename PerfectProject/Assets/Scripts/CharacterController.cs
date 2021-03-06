using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    
    Animator animator; 
    Rigidbody2D rb;
    bool canJump = true;
    public bool doubleJump;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Physics.gravity = new Vector3(0, -2.0F, 0);
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning",false);
        }
        
        if(moveInput>0)
        {
            transform.localScale= new Vector3(10,10,1);
        }
        else if (moveInput<0)
        {
            transform.localScale= new Vector3(-10,10,1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Platform"))
        {
            canJump = true;                
            doubleJump = true;
            animator.SetBool("isJumping",false);
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            animator.SetBool("isJumping",true);
            rb.AddForce(Vector2.up * (jumpSpeed * 2));
            canJump = false;
        } 
        
        
        
        else if (doubleJump == true)
        {
            animator.SetBool("isJumping",true);
            rb.AddForce(Vector2.up * (jumpSpeed * 2));
            canJump = false;
            doubleJump = false;
        }
    }

}
