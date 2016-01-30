using UnityEngine;
using System.Collections;

public class EdgeTile : MonoBehaviour
{
    [SerializeField] private bool isInUse = false;

    [SerializeField] private GameObject currentTrap;

    public bool GetIsInUse()
    {
        return isInUse;
    }

    public void SetIsInUse(bool _value)
    {
        isInUse = _value;
    }

    public void SetCurrentPlant(GameObject _trap)
    {
        currentTrap = _trap;
    }
}
