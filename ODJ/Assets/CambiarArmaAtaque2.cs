using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarArmaAtaque2 : MonoBehaviour
{

    public Sprite mySprite;
public float tiempo;

    public Sprite mySprite2;

    bool isAlive = true;
    bool first;
    // Start is called before the first frame update
    void Start()
    {
this.GetComponent<SpriteRenderer>().sprite = mySprite;
    first=true;
    }

    // Update is called once per frame
    void Update()
    {
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
