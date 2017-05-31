using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float lifeTime;//used to determine how long he object will wait to be destroyed

	void Start()
	{
		//the second parameter of Destroy is a time to execute the action of destruction.
		Destroy (gameObject, lifeTime);
	}
}
