using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarArmaAtaque : MonoBehaviour
{

    public Sprite mySprite;
public float tiempo;

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
    if (Input.GetKeyDown(KeyCode.C))
        {
            if (!isAlive)
            {
        StartCoroutine(ExampleCoroutine(tiempo));

            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAlive)
            {
                isAlive = false;
            }
            else
            {
                isAlive = true;
            }
        }
    }

    IEnumerator ExampleCoroutine(float tiempo)
    {
    this.GetComponent<SpriteRenderer>().sprite = mySprite2;
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(tiempo);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    this.GetComponent<SpriteRenderer>().sprite = mySprite;
    }
}
