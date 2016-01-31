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
	[SerializeField] private Image itemUI;
	[SerializeField] private Text itemNumber;

    // Use this for initialization
    void Start () {
		if (tools == null || tools.Count < 1) {
			tools = new List<int> (2){3,-1};
		}

		RenderTools ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Plant
		if (GameManager.Instance.state == GameManager.GameState.Playing) {
			if (Input.GetButtonDown ("P2_A"))
			{
				switch (currentTool) {
				case ToolType.Candy:
					if (currentTile != null && currentTile.GetComponent<EdgeTile> ().GetIsInUse () == false) {
						currentTile.GetComponent<EdgeTile> ().SetIsInUse (true);
						if (tools[(int)currentTool] > 0) {
							currentTile.GetComponent<EdgeTile>().SetTrap();
							tools[(int)currentTool]--;
							RenderTools ();
						}
					}
					break;
				case ToolType.Boot: 
					if (currentTile != null && currentTile.GetComponent<EdgeTile> ().GetIsInUse () == true) {
						//Boot
					}
					break;
				}
			}

			//Weapon Toggle
			if (Input.GetButtonDown ("P2_R1"))
			{
				int nextSeed = ((int)currentTool + 1);
				currentTool = nextSeed >= tools.Count ? 0 : (ToolType)nextSeed;
				RenderTools ();
			}
			else if (Input.GetButtonDown ("P2_L1"))
			{
				int nextSeed = ((int)currentTool - 1);
				currentTool = nextSeed < 0 ? (ToolType)(tools.Count-1) : (ToolType)nextSeed;
				RenderTools ();
			}
		}
    }

    public void SetCurrentTile(GameObject _tile)
    {
        currentTile = _tile;
    }

    void RenderTools() {
		int toolId = (int)currentTool;
		string path = "Materials/Tool" + toolId;
		Material m = Resources.Load(path) as Material;
		itemUI.material = m;

		if (tools[toolId] < 0) {
			itemNumber.text = "∞";
		}
		else itemNumber.text = "x" + tools[(int)currentTool];
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
