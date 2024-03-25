using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public EnemyAI enemyAI;
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
    public void Death()
    {
        enemyAI.enabled = false;
        _anim.SetBool("Die", true);
    }
    public void Hit()
    {
        _anim.SetTrigger("Hit");
    }
}
