using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Babushka : MonoBehaviour
{
    [SerializeField] private GameObject currentTile;
	
	// Update is called once per frame
	void Update ()
    {
		// Plant
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlantTile")
        {
            currentTile = other.gameObject;
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
