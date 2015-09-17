using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	
	public Room room;
	
	void Start() {
		
	}
	
	void Update() {
		
	}
	
	/// <summary>
	/// For now, load the room level
	/// </summary>
	public void Load() {
		room.Load();	
	}
}
