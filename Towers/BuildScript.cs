using UnityEngine;
using System.Collections;

public class BuildScript : MonoBehaviour {

	public bool isTemplate;
	public bool outOfButtons;

	private Camera mainCamera;
	private Vector3 cameraPos;
	
	void Awake() {
		mainCamera = GameObject.FindWithTag(Tags.gameCamera).camera;
		cameraPos = mainCamera.transform.position;
		isTemplate = false;
	}

	void Update() {
		if(isTemplate){
			Vector3 worldPoint;
			worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			//worldPoint.y = gameObject.collider.bounds.size.y / 2;
			float camDistance = Mathf.Sqrt(Mathf.Pow(cameraPos.x,2) + Mathf.Pow(cameraPos.y,2));
			worldPoint = ray.GetPoint(camDistance);
			//worldPoint.y += gameObject.collider.bounds.size.y / 2;
			worldPoint.y += 0.3f;
			transform.position = worldPoint;
			if(Input.GetMouseButtonUp(0) && outOfButtons)
			   isTemplate = false;
		}
	}
}
