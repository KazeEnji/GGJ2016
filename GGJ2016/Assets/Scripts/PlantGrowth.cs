using UnityEngine;
using System.Collections;

public partial class PlantGrowth : MonoBehaviour
{
    //This script will control the plant growth

    [Header("Plant Stages")]
    [SerializeField] private GameObject plantStage1;
    [SerializeField] private GameObject plantStage2;
    [SerializeField] private GameObject plantStage3;

    [SerializeField] private int currentStage;

    [Header("Time variables")]
    [SerializeField] private float timer = 0f;
    [SerializeField] private int seconds;
    
    private void Update()
    {
        PerformPlantGrowth();
    }

    private void PerformPlantGrowth()
    {
        timer += Time.deltaTime;
        seconds = Mathf.RoundToInt(timer % 60);

        switch (seconds)
        {
            case 5:
                {
                    IncrementPointValue();

                    currentStage = 1;

                    plantStage1.SetActive(true);
                    plantStage2.SetActive(false);
                    plantStage3.SetActive(false);
                    break;
                }
            case 10:
                {
                    IncrementPointValue();

                    currentStage = 2;

                    plantStage1.SetActive(false);
                    plantStage2.SetActive(true);
                    plantStage3.SetActive(false);
                    break;
                }
            case 20:
                {
                    IncrementPointValue();

                    currentStage = 3;

                    plantStage1.SetActive(false);
                    plantStage2.SetActive(false);
                    plantStage3.SetActive(true);
                    Debug.Log("Move to stage 3");
                    break;
                }
        }
    }

    public void TakeDamage()
    {
        switch (currentStage)
        {
            case 1:
                {
                    timer = 0f;
                    DecrementPointValue();
                    break;
                }
            case 2:
                {
                    timer = 6f;
                    DecrementPointValue();
                    break;
                }
            case 3:
                {
                    timer = 11f;
                    DecrementPointValue();
                    break;
                }
        }

    }
}
