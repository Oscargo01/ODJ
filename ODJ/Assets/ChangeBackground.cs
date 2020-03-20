using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeBackground : MonoBehaviour
{

    public TileBase tileA;
    public TileBase tileB;

    private Tilemap tilemap;

    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAlive)
            {
                tilemap.SwapTile(tileA, tileB);
                isAlive = false;
            }
            else
            {
                tilemap.SwapTile(tileB, tileA);
                isAlive = true;
            }
        }
    }

}


