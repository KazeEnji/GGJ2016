using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntAI : MonoBehaviour
{
    //Ant AI script
    [SerializeField] private Transform target;
    [SerializeField] private GameObject chamomile;
    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        chamomile = GameObject.FindGameObjectWithTag("Chamomile");
        GameManager.Instance.AddAnts(this.gameObject);
    }

    private void Update()
    {
        FindTarget();
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    public void DestroyAnt()
    {
        this.gameObject.SetActive(false);
    }

    public void FindTarget()
    {
        target = GameManager.Instance.FindTarget(this.gameObject);

        if(!target)
        {
            Debug.Log("Target is null");
            target = chamomile.transform;
        }
    }	
}
