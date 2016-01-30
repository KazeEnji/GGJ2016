using UnityEngine;
using System.Collections;

public class SunAndMoon : MonoBehaviour {

	private enum OrbitMode
	{
		Sun, Moon
	};

	private float radiusX = 7.5f;
	private float radiusY = 6;
	private float angle = 0;

	[SerializeField] private OrbitMode orbitType = OrbitMode.Moon;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		angle += Time.deltaTime * (Mathf.PI/GameManager.Instance.timeLimit);
		float x = radiusX * Mathf.Cos (angle + (orbitType == OrbitMode.Sun ? 0 : Mathf.PI));
		float y = radiusY * Mathf.Sin (angle) * (orbitType == OrbitMode.Sun ? 1 : -1);
		transform.localPosition = new Vector3 (x, 1.25f, -y-radiusY/2);
	}
}
