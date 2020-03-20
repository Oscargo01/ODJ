using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public Transform firePoint;

    bool vivo;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        vivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && vivo)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (vivo)
            {
                vivo = false;
            }
            else
            {
                vivo = true;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }
}
