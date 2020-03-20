using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemies : MonoBehaviour
{

    public Sprite mySprite;

    public Sprite mySprite2;

    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAlive)
            {
                this.GetComponent<SpriteRenderer>().sprite = mySprite2;
                isAlive = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = mySprite;
                isAlive = true;
            }
        }
    }
}
