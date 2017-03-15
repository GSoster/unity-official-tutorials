using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {


	// Update is called once per frame
	void Update () {
        //make the cube spin
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
