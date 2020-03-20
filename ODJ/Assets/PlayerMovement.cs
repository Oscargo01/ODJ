using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius,whatIsGround);

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
        if (doubleJump <=1 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {

                rb.velocity = Vector2.up * jumpForce;
                doubleJump++;

       }
        if (dash<1 && (Input.GetKeyDown(KeyCode.LeftShift))){ 
            controller.Move(horizontalMove * Time.fixedDeltaTime * dashDistance, false, jump);
            dash++;
        }

    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
