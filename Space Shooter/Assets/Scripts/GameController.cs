using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	//this script is responsible for spawning the hazards

	public GameObject hazard;
	public Vector3 spawnValues;


	//it is called in the first frame when this object is instantiated
	void Start(){
		SpawnWaves ();
	}

	void SpawnWaves()
	{
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;//Quaternion.identity means no rotation
		Instantiate (hazard, spawnPosition, spawnRotation);
	}

}
