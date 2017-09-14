using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMouseCursorController : MonoBehaviour {
	[HideInInspector]
	public Vector3 worldPoint;
	[HideInInspector]
	public RaycastHit cursorRayHit;

	private Camera mainCamera;
	private Vector3 cameraPos;
	private float camDistance;

	private Ray cursorRay;

	// RayCasting ignoring default layer (number 2), "Camera" (number 8) and "BuildTemplate" (number 10) layers, it will collide with 1s and ignore 0s
	// Bitshifting the layers 2, 8 and 9 and inverting the integer in binary
	private static int ignoreLayerMask = ~((1 << 2) + (1 << Tags.CameraLayer) + (1 << Tags.TemplateLayer));

	void Start () {
		mainCamera = GameObject.FindWithTag(Tags.gameCamera).GetComponent<Camera>();
		cameraPos = mainCamera.transform.position;	
	}

	void Update () {
		cursorRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		camDistance = Mathf.Sqrt(Mathf.Pow(cameraPos.x,2) + Mathf.Pow(cameraPos.y,2));	

		if (Physics.Raycast (cursorRay, out cursorRayHit, (int)camDistance, ignoreLayerMask)) {
			worldPoint = cursorRay.GetPoint (cursorRayHit.distance);
		}
	}
}
