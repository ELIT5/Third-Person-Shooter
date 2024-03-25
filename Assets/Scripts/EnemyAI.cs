using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public List<Transform> TargetPoints;
    public NavMeshAgent navMeshAgent;
    public PlayerController player;
    public bool isPlayerNoticed;
    public float viewAngle;
    private Animator _anim;
    public float damage = 30;
    private PlayerHealth playerHealth;
    public GameObject enemy;
    private EnemyHealth _enemyHealth;

    public bool IsAlive()
    {
        return _enemyHealth.IsAlive();
    }

    void Start()
    {
        InitComponentLinks();
        GoToRaandomTargetPoint();
        playerHealth = player.GetComponent<PlayerHealth>();
        _anim = enemy.GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }


    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
    }
     public void AttackUpdate()
    {
        if (isPlayerNoticed && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            _anim.SetTrigger("Attack");
        }
    }

    public void Attack()
    {
        playerHealth.DealDamage(damage);
    }

    private void GoToRaandomTargetPoint()
    {
        navMeshAgent.destination = TargetPoints[Random.Range(0, TargetPoints.Count)].position;
        navMeshAgent.stoppingDistance = 0;
    }


    private void PatrolUpdate()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !isPlayerNoticed)
        {
            GoToRaandomTargetPoint();
        }
    }


    private void InitComponentLinks()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    isPlayerNoticed = true;
                }
            }
        }
    }


    public void ChaseUpdate()
    {
        if (isPlayerNoticed)
        {
            navMeshAgent.destination = player.transform.position;
            navMeshAgent.stoppingDistance = 2;
        }
    }
}
