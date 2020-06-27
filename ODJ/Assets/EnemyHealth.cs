using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject enemigo;
    public Rigidbody2D pos;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage,float xpos)
    {
        currentHealth -= damage;
        Vector3 pushForce = new Vector3(200, 0, 0);
        float num = pos.position.x;
        if (num < xpos)
        {
            pushForce = -pushForce;
        }
        enemigo.GetComponent<Rigidbody2D>().AddForce(pushForce);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died! ");
        Destroy(enemigo);

    }
}
