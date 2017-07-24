using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	// 
	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");//gets the layer
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);
	}


	void Move(float h, float v)
	{
		movement.Set (h, 0f, v); //x, y, z. y will be zero
		//explanation:
		//if the player press to go in the horizontal and vertical directions
		//he will move more than just in one direction. So it is necessary
		//to use the normalized attribute of vector3;
		//also, we want the player to move by time not by frame, so we
		//need to calculate the movement by deltaTime.
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning()
	{
		//finds the point underneath the mouse
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;
		//if it hit something
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

	void Animating(float h, float v)
	{
		//if is there movement, then it is walking:
		bool isWalking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", isWalking);//set the value to the parameter in the Animator Controller (playerAC)
	}

}
