using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Dedushka : MonoBehaviour
{
    [SerializeField] private GameObject currentTile;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Trap
		if (Input.GetButtonDown ("P2_A"))
        {
            if (currentTile.GetComponent<EdgeTile>().GetIsInUse() == false)
            {
                currentTile.GetComponent<EdgeTile>().SetIsInUse(true);
                //Trap
            }
        }

		// Stomp
		if (Input.GetButtonDown ("P2_X"))
        {

		}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EdgeTile")
        {
            other.GetComponent<EdgeTile>().ActivateParticle();
            currentTile = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EdgeTile")
        {
            other.GetComponent<EdgeTile>().DeactivateParticle();
            currentTile = null;
        }
    }

    public void FreezeDedushka() {
		gameObject.GetComponent<ThirdPersonCharacter> ().enabled = false;
		gameObject.GetComponent<ThirdPersonUserControl2> ().enabled = false;
		gameObject.GetComponent<Animator> ().enabled = false;
		gameObject.GetComponent<Rigidbody> ().drag = 9999;
	}

	public void UnfreezeDedushka() {
		gameObject.GetComponent<ThirdPersonCharacter> ().enabled = true;
		gameObject.GetComponent<ThirdPersonUserControl2> ().enabled = true;
		gameObject.GetComponent<Animator> ().enabled = true;
		gameObject.GetComponent<Rigidbody> ().drag = 9999;
	}

}
