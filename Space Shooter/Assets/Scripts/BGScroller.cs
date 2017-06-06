using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;
	private Vector3 startPosition;
	public float tileSizeZ;//tile size along Z 	axis. Comes from the Scale (Y axis) of the transform in Background object

	void Start()
	{
		startPosition = transform.position;
	}


	// Update is called once per frame
	void Update () 
	{		
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;//Vector3.forward = x = 0, y = 0, z = 1
	}
}
