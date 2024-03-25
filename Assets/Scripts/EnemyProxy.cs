using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProxy : MonoBehaviour
{
    public EnemyAI enemyAI;
    public void Attack()
    {
        enemyAI.Attack();
    }
}
