﻿using UnityEngine;
using System.Collections;

public class PlantManager : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private int currentStage;

    [Header("Time variables")]
    [SerializeField] private float timer = 0f;

    [Header("Plant score value")]
    [SerializeField] private int plantValue = 1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.Play("PlantStage1_Plant");
    }

    private void Update()
    {
        Growth();
    }

    private void Growth()
    {
        timer += Time.deltaTime;

        if (timer >= 10f && currentStage == 0)
        {
            IncrementPointValue();

            anim.Play("PlantStage2_Growth");

            currentStage = 1;
        }
        else if (timer >= 20f && currentStage == 1)
        {
            IncrementPointValue();

            anim.Play("PlantStage3_Growth");

            currentStage = 2;
        }
        else if (timer >= 40f && currentStage == 2)
        {
            IncrementPointValue();

            currentStage = 3;
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