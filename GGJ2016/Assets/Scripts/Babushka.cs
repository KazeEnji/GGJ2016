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
	[SerializeField] private GameObject itemUI;
	[SerializeField] private Text itemNumber;


	void Start () {
		if (seeds == null || seeds.Count < 1) {
			seeds = new List<int> (4){1,0,0,3};
		}

		if (seeds[(int)currentSeed] < 0) {
			itemNumber.text = "∞";
		}
		else itemNumber.text = "x" + seeds[(int)currentSeed];
	}

	// Update is called once per frame
	void Update ()
    {
		// Plant
		if (GameManager.Instance.state == GameManager.GameState.Playing) {
			if (Input.GetButtonDown ("P1_A"))
	        {
	            if(currentTile.GetComponent<PlantTile>().GetIsInUse() == false)
	            {
	                currentTile.GetComponent<PlantTile>().SetIsInUse(true);
	                //Plant
	            }
			}

			// Water
			if (Input.GetButtonDown ("P1_X"))
	        {
	            if(currentTile.GetComponent<PlantTile>().GetIsInUse() == true)
	            {
	                //Water
	            }
			}
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlantTile")
        {
            other.GetComponent<PlantTile>().ActivateParticle();
            currentTile = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlantTile")
        {
            other.GetComponent<PlantTile>().DeactivateParticle();
            currentTile = null;
        }
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
