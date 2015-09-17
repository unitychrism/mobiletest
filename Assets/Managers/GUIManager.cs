using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	public  Texture2D 	crosshairTexture;
	private Rect 	  	crosshairPosition;
	static bool OriginalOn = true;
	
	// Use this for initialization
	void Start () {
		// Center crosshair pos
		crosshairPosition = new Rect((Screen.width - crosshairTexture.width) / 2, 
									 (Screen.height - crosshairTexture.height) / 2,
									  crosshairTexture.width, crosshairTexture.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		// Set crosshair
		if (OriginalOn == true) {
			GUI.DrawTexture(crosshairPosition, crosshairTexture);	
		}
		
		// Find char manager
		CharacterManager charManager = (CharacterManager)GameObject.Find("Main Camera").GetComponent("CharacterManager");
		float distanceFinder = charManager.distanceFinder;
		string nameFinder = charManager.nameFinder;
		
		// Make background box
		GUI.Box (new Rect(10,10,250,200), "Gridtastic Debug Mode");
		
		// Make textbox within
		GUI.TextArea (new Rect(20,40,230,100), "Distance: " + distanceFinder + "\n" +
				"Name: " + nameFinder
		);
		
		/*
		// Make first button, if pressed Application.LoadLevel(1)
		// will be executed
		if (GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel(1);	
		}
		
		// Make the second button
		if (GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			Application.LoadLevel(2);	
		}
		*/
		
	}
}
