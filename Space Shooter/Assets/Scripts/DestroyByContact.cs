using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		//Debug.Log (other.name);//debugging
		if(other.tag == "Boundary"){//we will not destroy if the contact is with Boundary
			return;
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
