using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;

	public Boundary ()
	{
		if (xMin == 0 || xMin == null) {
			xMin = -6;
		}
		if (xMax == 0 || xMax == null) {
			xMax = 6;
		}
		if (zMin == 0 || zMin == null) {
			zMin = -4;
		}
		if (zMax == 0 || zMax == null) {
			zMax = 8;
		}
	}

}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public Boundary boundary;
	public float tilt;
	void Start(){
		boundary = new Boundary ();
		rb = GetComponent<Rigidbody> ();
		if(speed == null || speed == 0){
			speed = 10;
		}

		if (tilt == null || tilt == 0) {
			tilt = 2.3f;
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement =  new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		//the clamp function clamps the values between 2
		rb.position = new Vector3 
			(
				Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * (-tilt));
	}
}
