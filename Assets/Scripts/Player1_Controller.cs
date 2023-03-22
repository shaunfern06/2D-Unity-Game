﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1_Controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public bool facingRight = true;
    private Rigidbody2D rb;

    private Animator animator;
    public Image HealthBar;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       extraJumps = extraJumpsValue;
       Vector2 velo = rb.velocity;
       animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {

       if (Input.GetKey(KeyCode.D))
       {
           rb.velocity = new Vector2(speed, rb.velocity.y);
       }
       else if (Input.GetKey(KeyCode.A))
       {
           rb.velocity = new Vector2(-speed, rb.velocity.y);
       }
       else
       {
           rb.velocity = new Vector2(0, rb.velocity.y);
       }


       isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

       if (facingRight == false && rb.velocity.x > 0)
       {
           Flip();
           HealthBar.transform.Rotate(0f, 180f, 0f);
       }
       else if (facingRight == true && rb.velocity.x < 0)
       {
           Flip();
           HealthBar.transform.Rotate(0f, 180f, 0f);
        }

    }
    void Update()
    {

       if (isGrounded == true)
       {
           extraJumps = 2;
            animator.SetBool("isJumping", false);
        }

       if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
       {
            animator.SetBool("isJumping", true);
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
           AudioManager.instance.Play("Jump");
           extraJumps -= extraJumps;
       }
    }

    void Flip()
    {
       facingRight = !facingRight;
       transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Lava"))
        {
            gameObject.GetComponent<TakeDamage>().Takedamage(100);
            AudioManager.instance.Play("Burn");
        }
    }
}
