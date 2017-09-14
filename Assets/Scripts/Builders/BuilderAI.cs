using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderAI : MonoBehaviour {
	public float builderSpeed = 10f;
	public float walkStopDistance = 0.5f;

	private float rotationSpeed = 10f;

	private Camera cameraRef;

	private float walkTimer;
	private UnityEngine.AI.NavMeshAgent nav;
	private Vector3 destination;
	private Animator animator;

	private GUIMouseCursorController cursorController;

	private bool bIsSelected = true;

	void Awake () {
		cameraRef = Camera.main.GetComponent<Camera> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
		destination = gameObject.transform.position;

		animator = GetComponent<Animator>();
		nav.speed = builderSpeed;

		cursorController = GameObject.FindWithTag(Tags.gameController).GetComponent<GUIMouseCursorController>();
	}

	void Update () {
		if (bIsSelected) {
			if (Input.GetMouseButtonUp (1)) {			
				destination = cursorController.worldPoint;

				animator.SetBool ("bShouldMove", true);
				animator.Play ("Locomotion");
			}

			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Locomotion")) {
				if (Vector3.Distance (gameObject.transform.position, destination) > walkStopDistance)
					nav.destination = this.destination;
				else {
					animator.SetBool ("bShouldMove", false);
				}
				
				Vector3 lookDirection = (destination - transform.position).normalized;
				Quaternion lookRotation = Quaternion.LookRotation (lookDirection);
				transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
			}
		}
	}
}
