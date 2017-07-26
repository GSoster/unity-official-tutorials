using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public GameController gameController;//to call the action GameOver
	public GameObject playerExplosion;

	bool isDead;
	bool damaged;

	void Awake()
	{
		currentHealth = startingHealth;
		gameController = GetComponent<GameController> ();
		//GameObject gameControllerObject = GameObject.FindWithTag ("GameController");//searching the object by tag
		//if (gameControllerObject != null) //if we have found the object
		//{
		//	gameController = gameControllerObject.GetComponent<GameController>();//get the script
		//}
	}

	public void TakeDamage (int amount)
	{
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;


		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}


	public void Death()
	{
		isDead = true;
		Instantiate (playerExplosion, transform.position, transform.rotation);
		gameController.GameOver ();
	}
}
