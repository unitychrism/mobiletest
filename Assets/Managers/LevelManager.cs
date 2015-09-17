using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public Level currentLevel;
	public Level[] levels;
	
	// Use this for initialization
	void Start () {
		if (currentLevel != null) {
			currentLevel.Load();	
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Initialize() {
		/*
		// If there is are levels available, take the first one and load
		if (levels.Length > 0) {
			currentLevel = levels[0];
			currentLevel.Load();
		}
		*/
	}
}
