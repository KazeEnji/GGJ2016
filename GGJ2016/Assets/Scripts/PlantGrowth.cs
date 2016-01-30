using UnityEngine;
using System.Collections;

public class PlantGrowth : MonoBehaviour
{
    //This script will control the plant growth

    [Header("Plant Stages")]
    [SerializeField] private GameObject plantStage1, plantStage2, plantStage3;

    [Header("Time variables")]
    [SerializeField] private float timer = 0f;
    [SerializeField] private int minutes, seconds;

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
                    Debug.Log("Do something");
                    break;
                }
        }
    }
}
