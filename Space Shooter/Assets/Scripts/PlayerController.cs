using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;

	public Boundary ()
	{
		if (xMin == 0) {
			xMin = -6;
		}
		if (xMax == 0) {
			xMax = 6;
		}
		if (zMin == 0) {
			zMin = -4;
		}
		if (zMax == 0) {
			zMax = 8;
		}
	}

}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	private AudioSource audioSource;//sound from the shot/bolt


	//powerUps
	public int shieldValue = 0;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play ();
		}

	}


	void Start()
	{
		boundary = new Boundary ();
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource >();

		if(speed == 0)
		{
			speed = 10;
		}

		if (tilt == 0) 
		{
			tilt = 2.3f;
		}
	}

	//it is run before every frame being draw
	void FixedUpdate()
	{
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
