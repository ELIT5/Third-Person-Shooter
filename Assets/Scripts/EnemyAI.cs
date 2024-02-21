using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public List<Transform> TargetPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerController player;
    private bool _isPlayerNoticed;
    public float viewAngle;



    void Start()
    {
        InitComponentLinks();
        GoToRaandomTargetPoint();
    }


    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }


    private void GoToRaandomTargetPoint()
    {
        _navMeshAgent.destination = TargetPoints[Random.Range(0, TargetPoints.Count)].position;
    }


    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0 && !_isPlayerNoticed)
        {
            GoToRaandomTargetPoint();
        }
    }


    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }


    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
