using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {
	public float dodge;
	public float smoothing;//how quickly it moves into the dodge
	public Vector2 startWait;//a waiting time to wait before starting to evade after the object is created
	public Vector2 maneuverTime;//(time in wich it will perform the maneuver. x = from, y = to)
	public Vector2 maneuverWait;//(time in wich it will wait before doing another maneuver. x = from, y = to)
	public Boundary boundary;

	private float currentSpeed;//rb.velocity.z (the velocity that the object is going towards the Z axis)
	private float targetManeuver;//a point in the X axis (left/right) to move
	private Rigidbody rb;

	//tilting effect
	public float tilt;


	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;
		StartCoroutine(Evade());	
	}


	IEnumerator Evade()
	{
		yield return new WaitForSeconds (Random.Range(startWait.x, startWait.y));

		while(true)
		{
			//Mathf.Sign = the "Sign" positive/negative of the value in the argument
			// - Mathf.Sign reverse the sign
			// - Mathf.Sign(transform.position.x) will return the opposite sign value to the x position. if +1 will return -1
			targetManeuver = Random.Range (1, dodge) * - Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range(maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random	.Range(maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate()
	{
		//Mathf.MoveTowards = Moves a value current towards target.
		float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
		rb.position = new Vector3 
			(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
			);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * - tilt);
	}
}
