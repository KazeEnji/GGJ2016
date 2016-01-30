using UnityEngine;
using System.Collections;

public class PlantTile : MonoBehaviour
{
    [SerializeField] private bool isInUse = false;

    [SerializeField] private GameObject currentPlant;
    [SerializeField] private GameObject plantSpawnPoint;

    public bool GetIsInUse()
    {
        return isInUse;
    }

    public void SetIsInUse(bool _value)
    {
        isInUse = _value;
    }

    public void SetCurrentPlant(GameObject _plant)
    {
        currentPlant = _plant;
    }
}
