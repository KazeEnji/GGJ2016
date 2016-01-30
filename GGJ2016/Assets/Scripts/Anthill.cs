using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Anthill : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private float spawnTime;

    [SerializeField] private int antCounter = 0;

    [SerializeField] private GameObject antPrefab;
    [SerializeField] private GameObject poolerLocation;

    [SerializeField] private List<GameObject> internalAntList = new List<GameObject>();

    private void Awake()
    {
        poolerLocation = GameObject.FindGameObjectWithTag("Pooler");
        Pooler();
        spawnTime = Time.time + spawnDelay;
    }

    private void Update()
    {
        SpawnAnts();
    }

    private void SpawnAnts()
    {
        if(spawnTime <= Time.time)
        {
            spawnTime = Time.time + spawnDelay;

            if (internalAntList[antCounter].activeSelf == false)
            {
                internalAntList[antCounter].transform.position = this.gameObject.transform.position;
                internalAntList[antCounter].SetActive(true);
            }

            if(antCounter < internalAntList.Count)
            {
                antCounter++;
            }
            else
            {
                antCounter = 0;
            }
        }
    }

    private void Pooler()
    {
        for(int i = 0; i < 30; i++)
        {
            GameObject _tempAnt = (GameObject)Instantiate(antPrefab, poolerLocation.transform.position, poolerLocation.transform.rotation);
            _tempAnt.name = this.gameObject.name + "_" + i;
            internalAntList.Add(_tempAnt);
            _tempAnt.SetActive(false);
        }
    }
}
