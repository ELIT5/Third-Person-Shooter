using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Enemy;
    public float enemyHealth;

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            Death();
        }
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }

    void Death()
    {
            Destroy(Enemy);
    }
}
