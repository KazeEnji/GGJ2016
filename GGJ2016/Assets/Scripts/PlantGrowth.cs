using UnityEngine;
using System.Collections;

public class PlantGrowth : MonoBehaviour
{
    //This script will control the plant growth

    [Header("Plant Stages")]
    [SerializeField] private GameObject plantStage1;
    [SerializeField] private GameObject plantStage2;
    [SerializeField] private GameObject plantStage3;

    [SerializeField] private int currentStage;

    [Header("Time variables")]
    [SerializeField] private float timer = 0f;

    [Header("Plant score value")]
    [SerializeField] private int plantValue = 1;

    private void Awake()
    {
        currentStage = 0;
    }
    
    private void Update()
    {
        PerformPlantGrowth();
    }

    private void PerformPlantGrowth()
    {
        timer += Time.deltaTime;

        if(timer >= 5f && currentStage == 0)
        {
            IncrementPointValue();

            currentStage = 1;

            plantStage1.SetActive(true);
            plantStage2.SetActive(false);
            plantStage3.SetActive(false);
        }
        else if(timer >= 10f && currentStage == 1)
        {
            IncrementPointValue();

            currentStage = 2;

            plantStage1.SetActive(false);
            plantStage2.SetActive(true);
            plantStage3.SetActive(false);
        }
        else if(timer >= 20f && currentStage == 2)
        {
            IncrementPointValue();

            currentStage = 3;

            plantStage1.SetActive(false);
            plantStage2.SetActive(false);
            plantStage3.SetActive(true);
        }
    }

    public void TakeDamage()
    {
        if(currentStage == 1)
        {
            currentStage--;
            timer = 0f;
            DecrementPointValue();
        }
        else if(currentStage == 2)
        {
            currentStage--;
            timer = 6f;
            DecrementPointValue();
        }
        else if(currentStage == 3)
        {
            currentStage--;
            timer = 11f;
            DecrementPointValue();
        }
    }

    private void IncrementPointValue()
    {
        GameManager.Instance.totalScore++;
    }

    private void DecrementPointValue()
    {
        GameManager.Instance.totalScore--;
    }
}
