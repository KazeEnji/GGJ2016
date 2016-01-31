using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	[SerializeField] public int needScore = 40;
    [SerializeField] public int totalScore;

	//Audio Manager
	[SerializeField] private AudioSource audioSource;	

	//Level Timer
	[SerializeField] public float timeLimit = 600f;
	public float timer = 0f;

	//Sky Manager
	[SerializeField] public Sky sky;

	//Plant Manager
	[SerializeField] public GameObject plants;

	//Babushka Manager
	[SerializeField] public Babushka babushka;

	//Dedushka Manager
	[SerializeField] public Dedushka dedushka;

    //Enemy Spawner

    //Enemy Manager
    [Header("Distance holders")]
    [SerializeField] public float distance1 = -1;
    [SerializeField] public float distance2 = -1;

    [Header("Closest object holders")]
    [SerializeField] public GameObject closestCandy;
    [SerializeField] public GameObject closestPlant;

    [Header("Lists")]
    [SerializeField] public List<GameObject> plantList = new List<GameObject>();
    [SerializeField] public List<GameObject> antList = new List<GameObject>();
    [SerializeField] public List<GameObject> candyList = new List<GameObject>();

	//Powerup Generator(?)

	// Use this for initialization
	void Start () {
		GameObject[] fadeins = GameObject.FindGameObjectsWithTag ("FadeInLoss");
		foreach (GameObject obj in fadeins) {
			MeshRenderer renderer = obj.GetComponent<MeshRenderer> ();
			if (renderer != null) {
				renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,0);
			}
		}
		GameObject[] fadein2 = GameObject.FindGameObjectsWithTag ("FadeInWin");
		foreach (GameObject obj in fadein2) {
			MeshRenderer renderer = obj.GetComponent<MeshRenderer> ();
			if (renderer != null) {
				renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,0);
			}
		}
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
				if (totalScore >= needScore) {
					state = GameState.Win;
					babushka.FreezeBabushka ();
					dedushka.FreezeDedushka ();
				} else {
					state = GameState.Lost;
					babushka.FreezeBabushka ();
					dedushka.FreezeDedushka ();
				}
			}
		} else if (GameManager.Instance.state == GameState.Lost) {
			GameObject[] fadeins = GameObject.FindGameObjectsWithTag ("FadeInLoss");
			GameObject[] fadeout = GameObject.FindGameObjectsWithTag ("FadeOutLoss");
			GameObject[] fadeout2 = GameObject.FindGameObjectsWithTag ("FadeOutAlways");
			foreach (GameObject obj in fadeins) {
				MeshRenderer renderer = obj.GetComponent<MeshRenderer> ();
				if (renderer != null) {
					float newAlpha = renderer.material.color.a + 0.025f;
					if (newAlpha >= 1) {
						newAlpha = 1;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
						break;
					}
					renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
				}
			}
			foreach (GameObject obj in fadeout) {
				MeshRenderer renderer = obj.GetComponent<MeshRenderer> ();
				if (renderer != null) {
					float newAlpha = renderer.material.color.a - 0.025f;
					if (newAlpha <= 0) {
						newAlpha = 0;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
						break;
					}
					renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
				}
			}
			foreach (GameObject obj in fadeout2) {
				MeshRenderer renderer = obj.GetComponent<MeshRenderer> ();
				if (renderer != null) {
					float newAlpha = renderer.material.color.a - 0.025f;
					if (newAlpha <= 0) {
						newAlpha = 0;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
						break;
					}
					renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
				}
			}
		} else if (GameManager.Instance.state == GameState.Win) {
			GameObject[] fadeins = GameObject.FindGameObjectsWithTag ("FadeInWin");
			GameObject[] fadeout = GameObject.FindGameObjectsWithTag ("FadeOutWin");
			GameObject[] fadeout2 = GameObject.FindGameObjectsWithTag ("FadeOutAlways");
			foreach (GameObject obj in fadeins) {
				MeshRenderer renderer = obj.GetComponent<MeshRenderer> ();
				if (renderer != null) {
					float newAlpha = renderer.material.color.a + 0.025f;
					if (newAlpha >= 1) {
						newAlpha = 1;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
						break;
					}
					renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
				}
			}
			foreach (GameObject obj in fadeout) {
				MeshRenderer renderer = obj.GetComponent<MeshRenderer> ();
				if (renderer != null) {
					float newAlpha = renderer.material.color.a - 0.025f;
					if (newAlpha <= 0) {
						newAlpha = 0;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
						break;
					}
					renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
				}
			}
			foreach (GameObject obj in fadeout2) {
				MeshRenderer renderer = obj.GetComponent<MeshRenderer> ();
				if (renderer != null) {
					float newAlpha = renderer.material.color.a - 0.025f;
					if (newAlpha <= 0) {
						newAlpha = 0;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
						break;
					}
					renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
				}
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

	void Win () {
		GameObject[] fadeins = GameObject.FindGameObjectsWithTag ("FadeInWin");
		GameObject[] fadeouts = GameObject.FindGameObjectsWithTag ("FadeOutWin");
		GameObject[] fadeouts2 = GameObject.FindGameObjectsWithTag ("FadeOutWin");
	}


    public void AddPlants(GameObject _plant)
    {
        plantList.Add(_plant);
        UpdateAnts();
    }

    public void AddAnts(GameObject _ant)
    {
        antList.Add(_ant);
    }

    public void AddCandy(GameObject _candy)
    {
        candyList.Add(_candy);
        UpdateAnts();
    }

    public void UpdateAnts()
    {
        foreach(GameObject _ant in antList)
        {
            _ant.GetComponent<AntAI>().FindTarget();
        }
    }

    public Transform FindTarget(GameObject _ant)
    {
        if(candyList.Count > 0)
        {
            foreach(GameObject _candy in candyList)
            {
                if(distance1 == -1)
                {
                    distance1 = Vector3.Distance(_ant.transform.position, _candy.transform.position);
                    closestCandy = _candy;
                }
                else
                {
                    distance2 = Vector3.Distance(_ant.transform.position, _candy.transform.position);
                }

                if(distance2 < distance1)
                {
                    distance1 = distance2;
                    closestCandy = _candy;
                }
            }

            return closestCandy.transform;
        }
        else if(plantList.Count > 0)
        {
            foreach (GameObject _plant in plantList)
            {
                if (distance1 == -1)
                {
                    distance1 = Vector3.Distance(_ant.transform.position, _plant.transform.position);
                    closestPlant = _plant;
                }
                else
                {
                    distance2 = Vector3.Distance(_ant.transform.position, _plant.transform.position);
                }

                if (distance2 < distance1)
                {
                    distance1 = distance2;
                    closestPlant = _plant;
                }
            }

            return closestPlant.transform;
        }

        distance1 = -1;
        distance2 = -1;
        closestCandy = null;
        closestPlant = null;

        return null;
    }
}
