using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

	public GameObject objectLookedAt;
	public float distanceFinder {get; private set;}
	public string nameFinder {get; private set;}
	
	public Material highlightMaterial;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Check for hit and print debug messaging
		GetLookedAtObject();
		
		// If there's a hit, light it up
		if (nameFinder != null) {
			// Find object
			objectLookedAt = GameObject.Find(nameFinder);
			objectLookedAt.GetComponent<Renderer>().material.color = Color.cyan;
			print ("changing " + nameFinder + " color.");
			
			// Destroy if button down
			if (Input.GetButtonDown("Fire1")) Destroy(objectLookedAt);
		}
	}
	
	private void GetLookedAtObject() {
		// Fire a ray from center of screen
		Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
		
		// Do raycast
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			// print ("Player looking at " + hit.transform.name);	
			distanceFinder = hit.distance;
			nameFinder = hit.collider.gameObject.name;
		} else {
			// print ("Not looking at anything");
			distanceFinder = -1f;
			nameFinder = null;
		}
	}
}
