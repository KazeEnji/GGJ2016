using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class ThirdPersonCustomCharacter : MonoBehaviour
{
	[SerializeField] float m_MoveSpeedMultiplier = 1f;
	[SerializeField] float m_AnimSpeedMultiplier = 1f;
	[SerializeField] float m_GroundCheckDistance = 0.1f;

	Rigidbody m_Rigidbody;
	Animator m_Animator;
	float m_OrigGroundCheckDistance;
	const float k_Half = 0.5f;
	Vector3 m_GroundNormal;
	float m_CapsuleHeight;
	Vector3 m_CapsuleCenter;
	CapsuleCollider m_Capsule;


	void Start()
	{
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
		m_Capsule = GetComponent<CapsuleCollider>();
		m_CapsuleHeight = m_Capsule.height;
		m_CapsuleCenter = m_Capsule.center;

		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		m_OrigGroundCheckDistance = m_GroundCheckDistance;
	}


	public void Move(Vector3 move, float xAxis, float yAxis)
	{

		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (move.magnitude > 1f) move.Normalize();


		Vector3 targetDirection = xAxis * Vector3.right + yAxis * Vector3.forward;
		if (!targetDirection.Equals(Vector3.zero))
			transform.rotation = Quaternion.LookRotation (targetDirection);

		HandleGroundedMovement(move + Vector3.down * 0.98f);

		// send input and other state parameters to the animator
		UpdateAnimator(move);
	}
		
	void HandleGroundedMovement(Vector3 move)
	{
		m_Rigidbody.velocity = move * 5 * m_MoveSpeedMultiplier;
		m_GroundCheckDistance = 0.1f;
	}


	void UpdateAnimator(Vector3 move)
	{
		m_Animator.SetBool("Moving", move.magnitude > 0.5f);
	}

	public void UpdateParam(string param, bool yes) {
		m_Animator.SetBool(param, yes);
	}

}
