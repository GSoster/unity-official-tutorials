using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;//how many points the user gets from destroying this object
	private GameController gameController;//to hold a instance of the gameController so we can call the function AddScore


	void Start()
	{
		//we need to search for the instantiated object GameController to find a reference to the script GameCotroller
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");//searching the object by tag
		if (gameControllerObject != null) //if we have found the object
		{
			gameController = gameControllerObject.GetComponent<GameController>();//get the script
		}

		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'GameController' Script");
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
		gameController.AddScore (scoreValue);
	}
}
