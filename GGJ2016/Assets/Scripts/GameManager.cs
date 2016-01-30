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

	//UI Manager

    //Score Manager
    [SerializeField] public int totalScore;

	//Audio Manager
	[SerializeField] private AudioSource audioSource;	

	//Level Timer
	[SerializeField] public float timeLimit = 600f;
	[SerializeField] private float timer = 0f;

	//Sky Manager
	[SerializeField] public Sky sky;

	//Plant Manager
	[SerializeField] public GameObject plants;

	//Babushka Manager
	[SerializeField] public Babushka babushka;

	//Dedushka Manager
	[SerializeField] public Dedushka dedushka;

	//Enemy Spawner

	//Powerup Generator(?)

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("P1_Start") || Input.GetButton ("P2_Start")) {
			Pause ();
		}
		if (GameManager.Instance.state == GameState.Playing) {
			if (timer < timeLimit) {
				timer += Time.deltaTime;
			} else {
				//Game End Logic
				state = GameState.Lost;
			}
		}
	}

	//Custom Methods

	void Pause() {
		if (GameManager.Instance.state == GameState.Playing) {
			GameManager.Instance.state = GameState.Paused;
			babushka.FreezeBabushka ();
			dedushka.FreezeDedushka ();
			audioSource.Pause ();
		} else if (GameManager.Instance.state == GameState.Paused) {
			GameManager.Instance.state = GameState.Playing;
			babushka.UnfreezeBabushka ();
			dedushka.UnfreezeDedushka ();
			audioSource.Play ();

		}
	}

}
