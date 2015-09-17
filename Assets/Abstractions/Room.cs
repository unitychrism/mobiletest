using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
	
	public Vector3 roomSize;
	public GameObject blockTemplate;
	
	private GameObject[] blocks;
	
	// Creates room out of current roomsize using block array
	public void Load() {
		// Initialize block array
		blocks = new GameObject[(int)roomSize.x * (int)roomSize.y * (int)roomSize.z];
		
		int i = 0;
		for (int incX = 0; incX < roomSize.x; incX++) {
			for (int incY = 0; incY < roomSize.y; incY++) {
				for (int incZ = 0; incZ < roomSize.z; incZ++) {	
					blocks[i] = (GameObject)GameObject.Instantiate(blockTemplate, new Vector3(incX, incY, incZ), Quaternion.identity);
					
					// Position block at x, y, z
					blocks[i].transform.position = new Vector3(incX, incY, incZ);
					blocks[i].tag = "block";
					blocks[i].name = "block" + i;
					
					// if odd, disable
					// if (i%2==0) blocks[i].SetActive(false);
					
					// if not the floor or walls, disable
					if ((incY > 0 && incX > 0 && incZ > 0) &&
						(incX < roomSize.x-1 && incY < roomSize.y && incZ < roomSize.z-1)) {
						
						// Keeps blocks available in memory (intensive)
						// blocks[i].SetActive(false);
						Destroy(blocks[i]);
					}
					
					// Increment count through
					i++;
				}
			}
		}	
	}
}
