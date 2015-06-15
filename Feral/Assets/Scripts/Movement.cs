using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class Movement : MonoBehaviour
{
	public float AnimationSpeed = 1.0f;
	public float TurnSpeed = 2.0f;

	private Animator anim = null;
	private Rigidbody thisRB = null;
	private AnimatorStateInfo currentBaseState;
	private GameObject thisGameObject = null;
	private GameMode Mode = GameMode.RPG;

	static int idleState = Animator.StringToHash("Idle.Idle");


	private bool rightMouseDown = false;
	private bool leftMouseDown = false;

	void Start ()
	{
		// initialising reference variables
		thisGameObject = gameObject;
		anim = GetComponent<Animator>();
		thisRB = thisGameObject.GetComponent<Rigidbody>();
		if (anim == null)
		{
			Debug.LogError("The game object on the Character Tracker has no animator.");
			return;
		}
	}
	
	
	void Update ()
	{
		if (!Input.GetButton("Mouse 0"))
		{
			leftMouseDown = false;
		}
		if (!Input.GetButton("Mouse 1"))
		{
			rightMouseDown = false;
		}

		
		//if the user has the right mouse button down and no direction buttons pressed, direction should respond to Mouse X movement
		float s = Input.GetAxis("Strafe");
		anim.SetFloat("Strafe", s);

		//Rotate character in place by horizontal axis. choose whether to do this permanently
		float h = Input.GetAxis("Horizontal");
		if (rightMouseDown || Mode == GameMode.FPS)
		{
			anim.SetFloat("Strafe", anim.GetFloat("Strafe") + h);
		}
		else
		{
			anim.SetFloat("Direction", h);	
			thisGameObject.transform.Rotate(0.0f, h * TurnSpeed, 0.0f, Space.World);
		}

		// if the user has both mouse buttons pressed, should move forward, otherwise respond to vertical input axis			
		if (leftMouseDown && rightMouseDown)
		{
			anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), 1, Time.deltaTime * 10));
		}
		else
		{
			float v = Input.GetAxis("Vertical");
			anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), v, Time.deltaTime * 10));
		}

		anim.speed = AnimationSpeed;
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
	}
}
	
