using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager mInstance;

	public static GameManager Instance {
		get {
			if (!mInstance) {
				GameManager existingManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
				if (existingManager)
					mInstance = existingManager;
				else
					mInstance = new GameObject ("GameManager").AddComponent<GameManager> ();
			}
			return mInstance;
		}
	}

	public enum GameState { StartScreen, Paused, Playing, Win, Lost };

	//Game State
	[SerializeField] public GameState state;

	//Level Timer
	[SerializeField] private float timeLimit = 600;
	[SerializeField] private float timer = 0f;
	[SerializeField] private int seconds = 0;

	//Sky Manager
	[SerializeField] public GameObject sky;

	//Plant Manager
	[SerializeField] public GameObject plants;

	//Babushka Manager
	[SerializeField] public GameObject babushka;

	//Dedushka Manager
	[SerializeField] public GameObject dedushka;

	//Enemy Spawner

	//Powerup Generator(?)

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.state == GameState.Playing) {
			if (seconds < timeLimit) {
				timer += Time.deltaTime;
				seconds = Mathf.RoundToInt(timer % 60);
			} else {
				//Level End
			}
		}	
	}
}
