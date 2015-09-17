using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	public float posX, posY, posZ;
	public int blockType = 1;
	public bool isLocked;
	
	public Color color {
		get {
			return GetComponent<Renderer>().material.color;	
		}
		set {
			GetComponent<Renderer>().material.color = value;	
		}
	}
	
	private float frequency = 0.6f;
	
	void Start() {
		color = Color.white;
	}
	
	void Update() {
		
		switch (blockType) {
		case 0: // darklight
		
			// Ignore the floor and locked cubes
			if (transform.position.y > 0.75 && !isLocked) {
				// Color cycle this cube
				float red = Mathf.Sin (frequency*transform.position.y*Mathf.PI/2 + 0 + (Time.timeSinceLevelLoad%100));
				float green = Mathf.Sin (frequency*transform.position.y*Mathf.PI/4 + 0 + (Time.timeSinceLevelLoad%100));
				float blue = Mathf.Sin (frequency*transform.position.y*Mathf.PI/6 + 0 + (Time.timeSinceLevelLoad%100));
				Color newColor = new Color(red, green, blue);
				GetComponent<Renderer>().material.color = newColor;
			} else {
				color = Color.white;	
			}
			/*
			if (Random.Range (0, 100) < 1) { // 10% chance to change color
				color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
			}
			*/
			
			break;
		case 1:
			if (transform.position.y > 0.75 && !isLocked) {
				float freqRed = 0.3f;
				float freqBlue = 0.6f;
				float freqGreen = 0.4f;
				Color newColor = new Color(Mathf.Sin(Time.timeSinceLevelLoad * freqRed)*transform.position.x, 
											Mathf.Sin(Time.timeSinceLevelLoad * freqGreen)*(transform.position.y+1),
											Mathf.Sin(Time.timeSinceLevelLoad * freqBlue)*transform.position.z);
				color = newColor;
			} else {
				color = Color.white;	
			}
			break;
		}
	}
}
