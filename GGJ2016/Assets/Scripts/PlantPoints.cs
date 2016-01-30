using UnityEngine;
using System.Collections;

public partial class PlantGrowth : MonoBehaviour
{
    [Header("Plant score value")]
    [SerializeField] private int plantValue = 1;

    private void IncrementPointValue()
    {
        plantValue++;
    }
    
    private void DecrementPointValue()
    {
        plantValue--;
    }
}
