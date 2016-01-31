﻿using UnityEngine;
using System.Collections;

public class EdgeTile : MonoBehaviour
{
    [SerializeField] private bool isInUse = false;

    [SerializeField] private ParticleSystem selectionParticle;

    [SerializeField] private GameObject currentTrap;
    [SerializeField] private GameObject trapSpawnPoint;

    private void Start()
    {
        selectionParticle = GetComponent<ParticleSystem>();
        selectionParticle.Stop();
    }

    public void ActivateParticle()
    {
        selectionParticle.Play();
    }

    public void DeactivateParticle()
    {
        selectionParticle.Stop();
    }

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
