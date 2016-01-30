using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntAI : MonoBehaviour
{
    //Ant AI script
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    private void FindTarget()
    {
        //Pull target from game manager
    }
}
