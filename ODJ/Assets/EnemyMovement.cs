using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;

    public float checkRadius;
    public LayerMask whatIsGround;
    bool isGrounded = true;
    public Transform enemyPosF;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        isGrounded = Physics2D.OverlapCircle(enemyPosF.position, checkRadius, whatIsGround);
        if (groundInfo.collider == false || isGrounded)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}