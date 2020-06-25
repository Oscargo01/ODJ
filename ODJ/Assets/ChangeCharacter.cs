using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{

    public Sprite mySprite;

    public Sprite mySprite2;

    bool isAlive = true;
    bool first;
    // Start is called before the first frame update
    void Start()
    {
	first=true;
    }

    // Update is called once per frame
    void Update()
    {
if(first){
  if (isAlive)
            {
                this.GetComponent<SpriteRenderer>().sprite = mySprite;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = mySprite2;
            }
first=false;
}
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