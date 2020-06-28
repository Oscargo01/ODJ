using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public Rigidbody2D PlayerBody;
    public float Speed = 3f;
    public int Ts;
    bool up = false;
    void Awake()
    {
        PlayerBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Speed = Speed * -1;
            PlayerBody.gravityScale = Speed;
            gameObject.transform.RotateAround(transform.position, Vector3.back * (-1), Ts);
            
            if (up)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1);
            }
            else
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1);
            }
            up = !up;
        }
    }
}
