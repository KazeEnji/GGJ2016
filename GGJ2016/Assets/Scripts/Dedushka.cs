using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class Dedushka : MonoBehaviour
{
	public enum ToolType {
		Candy = 0, Boot = 1
	}

    [SerializeField] private GameObject currentTile;
	[SerializeField] public List<int> tools;
	[SerializeField] public ToolType currentTool = ToolType.Boot;
	[SerializeField] private GameObject itemUI;
	[SerializeField] private Text itemNumber;

    // Use this for initialization
    void Start () {
		if (tools == null || tools.Count < 1) {
			tools = new List<int> (2){3,-1};
		}

		if (tools [(int)currentTool] < 0) {
			itemNumber.text = "∞";
		}
		else itemNumber.text = "x" + tools[(int)currentTool];
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EdgeTile")
        {
            currentTile = other.gameObject;
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
