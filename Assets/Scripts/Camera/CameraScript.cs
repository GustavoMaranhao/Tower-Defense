using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public float defaultElevation = 1.05f;

	public float cameraSpeed = 10.0F;

	private int RBound = 1, LBound = 1, UBound = 1, DBound = 1;

	void Start () {
		transform.position = new Vector3 (0, defaultElevation, 0);
	}

	void Update () {
		float x = cameraSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime;
		float z = cameraSpeed * Input.GetAxis ("Vertical") * Time.deltaTime;

		if (x > 0) {
			x *= RBound;
		} else if (x < 0) {
			x *= LBound;
		}

		if (z > 0) {
			z *= UBound;
		} else if (z < 0) {
			z *= DBound;
		}

		transform.Translate (x, 0, z);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == Tags.boundaries) {
			switch (collision.gameObject.name) {
			case "RightBoundary":
				RBound = 0;
				break;
			case  "LeftBoundary":
				LBound = 0;
				break;
			case "UpperBoundary":
				UBound = 0;
				break;
			case "LowerBoundary":
				DBound = 0;
				break;
			}
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == Tags.boundaries) {
			switch (collision.gameObject.name) {
			case "RightBoundary":
				RBound = 1;
				break;
			case  "LeftBoundary":
				LBound = 1;
				break;
			case "UpperBoundary":
				UBound = 1;
				break;
			case "LowerBoundary":
				DBound = 1;
				break;
			}
		}
	}
}
