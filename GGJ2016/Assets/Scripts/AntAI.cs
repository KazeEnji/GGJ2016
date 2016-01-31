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
    [SerializeField] private bool isHeadedHome = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        chamomile = GameObject.FindGameObjectWithTag("Chamomile");
        GameManager.Instance.AddAnts(this.gameObject);
    }

    private void Update()
    {
        if(GameManager.Instance.state == GameManager.GameState.Playing)
        {
            MoveToTarget();
        }
        else if(GameManager.Instance.state == GameManager.GameState.Lost)
        {
            this.gameObject.SetActive(false);
        }
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
        if(_other.tag == "RedFlower")
        {
            Debug.Log("Hit a flower");
            isHeadedHome = true;
            target = homeAnthill.transform;
        }
        else if(_other.tag == "Anthill")
        {
            isHeadedHome = false;
            FindTarget();
        }
    }

    public void FindTarget()
    {
        if(isHeadedHome == false)
        {
            target = GameManager.Instance.FindTarget(this.gameObject);

            if (!target)
            {
                target = chamomile.transform;
            }
        }
    }	
}
