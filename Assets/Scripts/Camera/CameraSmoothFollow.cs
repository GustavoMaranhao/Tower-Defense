using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {

	public GameObject cameraTarget;
	public float followSpeed = 20f;

	public float zoomIncrement = 15.0F;	
	public int maxZoom = 30;
	public int minZoom = 5;

	private Transform endTarget;
	private Camera cameraRef;

	void Start () {
		endTarget = cameraTarget.transform.GetChild (0).transform;

		cameraRef = gameObject.GetComponent<Camera>();
	}

	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, endTarget.position, followSpeed * Time.deltaTime);

		float mouseWheel = -Input.GetAxis ("Mouse ScrollWheel");
		if (mouseWheel != 0) 
			cameraRef.fieldOfView = Mathf.Clamp(cameraRef.fieldOfView + mouseWheel * zoomIncrement, minZoom, maxZoom);
	}
}
