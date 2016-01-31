using UnityEngine;
using System.Collections;

public class PlantManager : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private int currentStage;

    [Header("Time variables")]
	[SerializeField] private float growthTimer = 0f;
	[SerializeField] private float pointTimer = 0f;
	[SerializeField] private float pointPeriod = 15;

    [Header("Plant score value")]
    [SerializeField] private int plantValue = 1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.Play("PlantStage1_Plant");
    }

    private void Update()
    {
		pointTimer += Time.deltaTime;
		if (pointTimer > pointPeriod) {
			GameManager.Instance.chamomile.totalScore += plantValue;
			pointTimer = 0;
		}
        Growth();
    }

    private void Growth()
    {
		if (growthTimer < 40f) {
			growthTimer += Time.deltaTime;
		} else
			growthTimer = 40f;

		if (growthTimer >= 10f && currentStage == 0)
        {
            IncrementPointValue();
            anim.Play("PlantStage2_Growth");

            currentStage = 1;
        }
		else if (growthTimer >= 20f && currentStage == 1)
		{
            IncrementPointValue();
            anim.Play("PlantStage3_Growth");

            currentStage = 2;
        }
		else if (growthTimer >= 40f && currentStage == 2)
		{
            IncrementPointValue();
            currentStage = 3;
        }
    }

	public void IncrementPointValue()
    {
		plantValue++;
    }

   	public void DecrementPointValue()
    {
		plantValue--;
		currentStage--;
		growthTimer -= 15f;
    }
}
