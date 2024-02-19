using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public Transform[] TargetPoints;
    private NavMeshAgent _navMeshAgent;
    private bool _goToTargetPoint = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_goToTargetPoint)
        {
            GoToRandomTargetPoint();
        }
    }
    void GoToRandomTargetPoint()
    {
        _goToTargetPoint = true;
        int i = Random.Range(0, TargetPoints.Length);
        _navMeshAgent.destination = TargetPoints[i].position;
        while (_goToTargetPoint)
        {
            if (Mathf.Abs(transform.position.x - TargetPoints[i].position.x) < 0.1 && Mathf.Abs(transform.position.z - TargetPoints[i].position.z) < 0.1)
            {
                _goToTargetPoint = false;
            }
        }
    }
}
