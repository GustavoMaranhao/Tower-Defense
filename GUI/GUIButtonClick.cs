using UnityEngine;
using System.Collections;

public enum BUTTONTYPES { 
	General = 0, 
	Building = 1
}

public class GUIButtonClick : MonoBehaviour {

	public BUTTONTYPES buttonType;
	public string[] buttonHelp = new string[] {"Name", "Cost", "Description"};
	public GameObject toBuild;
	public float toolTipBoxHorLocation;
		
	private bool bTooltipBox;
	private GameObject template;
	private GUIStyle toolNameStyle;
	private GUIStyle toolCostStyle;
	private GUIStyle toolDescStyle;

	void Awake(){
		toolNameStyle = new GUIStyle();
		toolNameStyle.normal.textColor = Color.white;
		toolNameStyle.wordWrap = true;
		toolNameStyle.fontSize = 18;
		toolNameStyle.fontStyle = FontStyle.Bold;
		
		toolCostStyle = new GUIStyle();
		toolCostStyle.normal.textColor = Color.yellow;
		toolCostStyle.wordWrap = true;
		toolNameStyle.fontSize = 14;

		toolDescStyle = new GUIStyle();
		toolDescStyle.normal.textColor = Color.white;
		toolDescStyle.wordWrap = true;
		toolDescStyle.fontSize = 12;
	}

	void OnMouseEnter(){
		bTooltipBox = true;
		if(template!=null)
			template.GetComponent<BuildScript>().outOfButtons = false;
	}

	void OnMouseDown(){
		template  = Instantiate(toBuild, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		template.GetComponent<BuildScript>().isTemplate = true;
	}
		
	void OnMouseUp(){
	}
		
	void OnMouseExit(){
		bTooltipBox = false;
		if(template!=null)
			template.GetComponent<BuildScript>().outOfButtons = true;

	}

	void OnGUI(){
		if(bTooltipBox){
			switch(buttonType){
			case BUTTONTYPES.General:
				GUILayout.BeginArea(new Rect(toolTipBoxHorLocation, Screen.height - Screen.height/3.5f, 100, 100));
				GUILayout.Label(buttonHelp[0], toolNameStyle);
				GUILayout.Label(buttonHelp[1], toolCostStyle);
				GUILayout.Label(buttonHelp[2]);
				GUILayout.EndArea();
				break;
			case BUTTONTYPES.Building:
				GUILayout.BeginArea(new Rect(toolTipBoxHorLocation, Screen.height - Screen.height/3.5f, 100, 100));
				GUILayout.Label(buttonHelp[0], toolNameStyle);
				GUILayout.Label(buttonHelp[1], toolCostStyle);
				GUILayout.Label(buttonHelp[2]);
				GUILayout.EndArea();
				break;
			}
		}
	}

}
