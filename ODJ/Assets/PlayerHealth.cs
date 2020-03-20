using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public float checkRadius;

    public LayerMask enemy;
    bool touchingEnemy = false;
    public Transform feetPos;
    public Transform headPos;
    public Transform frontPos;
    public Transform backPos;
    public float timeBetweenDamage;
    float time=0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        bool touchingEnemy1 = Physics2D.OverlapCircle(feetPos.position, checkRadius, enemy);
        bool touchingEnemy2 = Physics2D.OverlapCircle(headPos.position, checkRadius, enemy);
        bool touchingEnemy3 = Physics2D.OverlapCircle(frontPos.position, checkRadius, enemy);
        bool touchingEnemy4 = Physics2D.OverlapCircle(backPos.position, checkRadius, enemy);
        touchingEnemy = touchingEnemy1 || touchingEnemy2|| touchingEnemy3||touchingEnemy4;
        if (touchingEnemy)
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        if (time > timeBetweenDamage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            time = 0;
        }   
    }

}
