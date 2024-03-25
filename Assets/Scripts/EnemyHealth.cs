using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Enemy;
    public float enemyHealth;
    private EnemyAnimationController _anim;

    public bool IsAlive()
    {
        return enemyHealth  > 0;
    }
    private void Start()
    {
        _anim = FindObjectOfType<EnemyAnimationController>();
    }


    private void Update()
    {
        if (enemyHealth <= 0)
        {
            _anim.Death();
        }
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        _anim.Hit();
    }
}
