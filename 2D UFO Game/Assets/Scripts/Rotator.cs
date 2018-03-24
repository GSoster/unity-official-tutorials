using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {


	// Update is called once per frame
	void Update () 
	{
		// rotates around the Z axys
		// multiplies by Time.deltaTime to be a smooth rotation
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);	
	}
}
