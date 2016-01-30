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

	//Plant Manager

	//Babushka Manager

	//Dedushka Manager

	//Enemy Spawner

	//Powerup Generator(?)

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
