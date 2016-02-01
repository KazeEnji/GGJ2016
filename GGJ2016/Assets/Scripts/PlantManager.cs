using UnityEngine;
using System.Collections;

public class PlantManager : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private int currentStage = 0;

    [Header("Time variables")]
	[SerializeField] private float growthTimer = 0f;
	[SerializeField] private float pointTimer = 0f;
	[SerializeField] private float pointPeriod = 5; // 5 seconds to grand points

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

		//TODO: Time to next growth instead of set times
		if (growthTimer >= 10f)
        {
            IncrementPointValue();
        }
		else if (growthTimer >= 20f)
		{
            IncrementPointValue();
        }
		else if (growthTimer >= 40f)
		{
            IncrementPointValue();
        }
    }

	public void IncrementPointValue()
	{
		plantValue++;
		currentStage++;
		if (currentStage > 1 && currentStage < 3) {
			anim.Play ("PlantStage" + (currentStage+1) + "_Growth");
		}
    }

   	public void DecrementPointValue()
    {
		if(currentStage < 3)
        {
            plantValue--;
			if (currentStage > 0) currentStage--;
			anim.Play ("PlantStage" + (currentStage+1) + "_Idle");
			growthTimer = Mathf.Max(growthTimer - 15f, 0) ;
        }
    }
}
