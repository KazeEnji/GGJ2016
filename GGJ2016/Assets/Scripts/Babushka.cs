using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class Babushka : MonoBehaviour
{
	public enum SeedType {
		Yellow = 0, Red = 1, White = 2, Water = 3
	}

    [SerializeField] private GameObject currentTile;
	[SerializeField] public List<int> seeds;
	[SerializeField] public SeedType currentSeed = SeedType.Yellow;
	[SerializeField] private Image itemUI;
	[SerializeField] private Text itemNumber;


	void Start () {
		if (seeds == null || seeds.Count < 1) {
			seeds = new List<int> (4){1,0,0,3};
		}

		RenderSeeds ();
	}

	// Update is called once per frame
	void Update ()
    {
		// Plant
		if (GameManager.Instance.state == GameManager.GameState.Playing) {
			if (Input.GetButtonDown ("P1_A"))
	        {
				switch (currentSeed) {
				case SeedType.Red:
				case SeedType.Yellow:
				case SeedType.White:
					if (currentTile.GetComponent<PlantTile> ().GetIsInUse () == false) {
					currentTile.GetComponent<PlantTile> ().SetIsInUse (true);
						//Plant
					}
					break;
				case SeedType.Water: 
					if (currentTile.GetComponent<PlantTile> ().GetIsInUse () == true) {
						//Water
					}
					break;
				}
			}

			//Weapon Toggle
			if (Input.GetButtonDown ("P1_R1"))
			{
				int nextSeed = ((int)currentSeed + 1);
				currentSeed = nextSeed >= seeds.Count ? 0 : (SeedType)nextSeed;
				RenderSeeds ();
			}
			else if (Input.GetButtonDown ("P1_L1"))
			{
				int nextSeed = ((int)currentSeed - 1);
				currentSeed = nextSeed < 0 ? (SeedType)(seeds.Count-1) : (SeedType)nextSeed;
				RenderSeeds ();
			}
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlantTile")
        {
            currentTile = other.gameObject;
        }
    }

	void RenderSeeds() {
		int seedId = (int)currentSeed;
		string path = "Materials/Seed" + seedId;
		Material m = Resources.Load(path) as Material;
		itemUI.material = m;

		if (seeds[seedId] < 0) {
			itemNumber.text = "∞";
		}
		else itemNumber.text = "x" + seeds[(int)currentSeed];
	}

	public void FreezeBabushka() {
		gameObject.GetComponent<ThirdPersonCharacter> ().enabled = false;
		gameObject.GetComponent<ThirdPersonUserControl> ().enabled = false;
		gameObject.GetComponent<Animator> ().enabled = false;
		gameObject.GetComponent<Rigidbody> ().drag = 9999;
	}

	public void UnfreezeBabushka() {
		gameObject.GetComponent<ThirdPersonCharacter> ().enabled = true;
		gameObject.GetComponent<ThirdPersonUserControl> ().enabled = true;
		gameObject.GetComponent<Animator> ().enabled = true;
		gameObject.GetComponent<Rigidbody> ().drag = 0;
	}

}
