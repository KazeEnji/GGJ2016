using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (ThirdPersonCustomCharacter))]
public class ThirdPersonUserControl : MonoBehaviour
{
	private ThirdPersonCustomCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward;             // The current forward direction of the camera
	private Vector3 m_Move;

	[SerializeField] private AudioClip footstep;

	private void Start()
	{
		// get the transform of the main camera
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
		}

		// get the third person character ( this should never be null due to require component )
		m_Character = GetComponent<ThirdPersonCustomCharacter>();
	}


	private void Update()
	{

	}


	// Fixed update is called in sync with physics
	private void FixedUpdate()
	{
		// read inputs
		float h = CrossPlatformInputManager.GetAxis("P1_LJ_X");
		float v = CrossPlatformInputManager.GetAxis("P1_LJ_Y");

		m_Move = new Vector3(h, 0, v);

		// pass all parameters to the character control script
		if (GameManager.Instance.state == GameManager.GameState.Playing) {
			AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
			if (audioSource && !audioSource.isPlaying && ((m_Move.x > 0.2  || m_Move.x < -0.2) || (m_Move.y > 0.2  || m_Move.y < -0.2))) {
				audioSource.clip = footstep;
				audioSource.volume = 0.25f;
				audioSource.Play ();
			}
			m_Character.Move (m_Move, h, v);
		}
	}
}