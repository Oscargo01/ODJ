using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 30;

    bool vivo;

    void Start()
    {
        vivo = true;
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&& !vivo)
        {
            Attack();
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
    void Attack()
    {
     Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
    foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
         }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
