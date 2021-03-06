﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Transform feetPos;
    public float jumpForce;
    public float runSpeed = 40f;
    private Rigidbody2D rb;
    public float checkRadius;
    public LayerMask whatIsGround;
    bool isGrounded = true;
    int doubleJump = 0;
    public float dashDistance;

    float horizontalMove = 0f;

    int counter = 0;

    int dash = 0;

    bool jump = false;

    public bool vivo;

    public Sprite mySprite;

    public Sprite mySprite2;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius,whatIsGround);

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
      

        if (isGrounded==true)
        {
            dash = 0;
            doubleJump = 0;
        }
        else
        {
            if (doubleJump == 0)
            {
                doubleJump++;
            }     
        }
        if (doubleJump <=1 && Input.GetKeyDown(KeyCode.Z))
        {
                rb.velocity = Vector2.up * jumpForce;
                doubleJump++;

       }
        if (dash<1 && (Input.GetKeyDown(KeyCode.X))){ 
            controller.Move(horizontalMove * Time.fixedDeltaTime * dashDistance, false, jump);
            dash++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isAlive", vivo);
            if (vivo)
            {
                this.GetComponent<SpriteRenderer>().sprite = mySprite;
                vivo = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = mySprite2;
                vivo = true;
            }
            
        }

    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
