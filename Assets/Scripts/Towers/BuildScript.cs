using UnityEngine;
using System.Collections;

public class BuildScript : MonoBehaviour {
	[HideInInspector]
	public bool isTemplate;
	[HideInInspector]
	public bool outOfButtons;

	private GUIMouseCursorController cursorController;

	private bool bAllowBuild = true;
	
	void Awake() {
		isTemplate = false;

		cursorController = GameObject.FindWithTag(Tags.gameController).GetComponent<GUIMouseCursorController>();
	}

	void Update() {
		if(isTemplate){
		    if (cursorController.cursorRayHit.collider.gameObject.layer == Tags.TowersLayer)
				bAllowBuild = false;
			else
				bAllowBuild = true;

			transform.position = cursorController.worldPoint;
			if (Input.GetMouseButtonUp (0) && outOfButtons && bAllowBuild) {
				isTemplate = false;
				GetComponent<Renderer>().material.color = Color.gray;
				gameObject.layer = Tags.TowersLayer;
			}

			if (gameObject.layer == Tags.TemplateLayer)
				if (bAllowBuild)
					GetComponent<Renderer>().material.color = Color.green;
				else
					GetComponent<Renderer>().material.color = Color.red;

			if (Input.GetKey (KeyCode.Escape))
				Destroy (gameObject);
		}
	}
}