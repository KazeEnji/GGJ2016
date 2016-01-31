using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntAI : MonoBehaviour
{
    //Ant AI script
    [SerializeField] private Transform target;
    [SerializeField] private GameObject chamomile;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject homeAnthill;

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

    public void SetHomeAntHill(GameObject _home)
    {
        homeAnthill = _home;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if(_other.tag == "PlantTile" && _other.GetComponent<PlantTile>().GetIsInUse())
        {
            target = homeAnthill.transform;
        }
    }

    public void FindTarget()
    {
        target = GameManager.Instance.FindTarget(this.gameObject);

        if(!target)
        {
            target = chamomile.transform;
        }
    }	
}
