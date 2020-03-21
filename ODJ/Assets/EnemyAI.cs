using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float visionRadius;
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    public float checkRadius;
    public LayerMask whatIsGround;
    bool isGrounded = true;
    public Transform enemyPosF;
    GameObject player;
    Vector3 initialPosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
    }

    void Update()
    {
        Vector3 target = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) {
            target = player.transform.position;
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }
        else
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

        Debug.DrawLine(transform.position, target, Color.green);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
