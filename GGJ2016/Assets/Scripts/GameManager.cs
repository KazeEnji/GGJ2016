using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

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

	//Audio Manager
	[SerializeField] private AudioSource audioSource;

	//Level Timer
	[SerializeField] private float timeLimit = 600f;
	private float timer = 0f;

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
			FreezeBabushka ();
			FreezeDedushka ();
			audioSource.Pause ();
		} else if (GameManager.Instance.state == GameState.Paused) {
			GameManager.Instance.state = GameState.Playing;
			UnfreezeBabushka ();
			UnfreezeDedushka ();
			audioSource.Play ();

		}
	}

	void FreezeBabushka() {
		babushka.GetComponent<ThirdPersonCharacter> ().enabled = false;
		babushka.GetComponent<ThirdPersonUserControl> ().enabled = false;
		babushka.GetComponent<Animator> ().enabled = false;
		babushka.GetComponent<Rigidbody> ().drag = 9999;
	}

	void UnfreezeBabushka() {
		babushka.GetComponent<ThirdPersonCharacter> ().enabled = true;
		babushka.GetComponent<ThirdPersonUserControl> ().enabled = true;
		babushka.GetComponent<Animator> ().enabled = true;
		babushka.GetComponent<Rigidbody> ().drag = 0;
	}

	void FreezeDedushka() {
		dedushka.GetComponent<ThirdPersonCharacter> ().enabled = false;
		dedushka.GetComponent<ThirdPersonUserControl2> ().enabled = false;
		dedushka.GetComponent<Animator> ().enabled = false;
		dedushka.GetComponent<Rigidbody> ().drag = 9999;
	}

	void UnfreezeDedushka() {
		dedushka.GetComponent<ThirdPersonCharacter> ().enabled = true;
		dedushka.GetComponent<ThirdPersonUserControl2> ().enabled = true;
		dedushka.GetComponent<Animator> ().enabled = true;
		dedushka.GetComponent<Rigidbody> ().drag = 9999;
	}
}
