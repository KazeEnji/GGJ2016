using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Babushka : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Plant
		if (Input.GetButtonDown ("P1_A")) {

		}

		// Water
		if (Input.GetButtonDown ("P1_X")) {

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
