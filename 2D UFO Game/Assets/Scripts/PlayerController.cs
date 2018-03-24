using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;
	private int count;
	private int maxPickUpsQuantity;
	public Text countText;
	public Text winText;

	void Start ()
	{		
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		maxPickUpsQuantity = 12;
	}


	//Physics code
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{			
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= maxPickUpsQuantity) 
		{
			winText.text = "You Win!";
		}
	}
}
