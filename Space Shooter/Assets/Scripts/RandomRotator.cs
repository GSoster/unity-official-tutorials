using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;//tremer,girar
	private Rigidbody rb;
	void Start(){
		rb = GetComponent<Rigidbody> ();
		//Random.insideUnitSphere gives a random vector3
		rb.angularVelocity  = Random.insideUnitSphere * tumble;//angularVelocity is how fast a gameobject is rotating

	}
}
