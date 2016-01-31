using UnityEngine;
using System.Collections;

public class Chamomile : MonoBehaviour {

	[SerializeField] public int needScore = 40;
	[SerializeField] public int totalScore;

	private int growthStage = 1;

	// Use this for initialization
	void Start () {
		totalScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.state == GameManager.GameState.Playing) {
			float percentage = ((float)totalScore / (float)needScore) * 100;
			int newGrowthStage = 1;
			if (percentage >= 100) {
				newGrowthStage = 5;
			} else if (percentage >= 75) {
				newGrowthStage = 4;
			} else if (percentage >= 50) {
				newGrowthStage = 3;
			} else if (percentage >= 25) {
				newGrowthStage = 2;
			} else {
				newGrowthStage = 1;
			}

			if (newGrowthStage != growthStage) {
				growthStage = newGrowthStage;
				string path = "Materials/camo" + growthStage;
				Material m = Resources.Load(path) as Material;
				gameObject.GetComponentInChildren<MeshRenderer> ().material = m;
			}
		}
	}
}
