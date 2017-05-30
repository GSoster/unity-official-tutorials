using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	private Rigidbody rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		if (speed == 0) {
			speed = 20;
		}

		// The z Axis is also known as Transform Forward
		rb.velocity = transform.forward * speed;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
