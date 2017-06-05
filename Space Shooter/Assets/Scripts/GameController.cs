using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	//this script is responsible for spawning the hazards

	public Vector3 spawnValues;
	public float hazardCount;
	public float spawnWait;//wait time between one spawn hazard and another
	public float startWait;//wait time when the game first start so the player can get ready;
	public float waveWait;//how much time we await between waves
	public GameObject[] hazards;//asteroids and enemy ships

	// ##### GUI ##########
	//public GUIText scoreText;//to display the score
	private Text scoreText;//to display the score
	public GameObject scoreTextCanvas;//holds the text that displays the score
	private int score;

	public GameObject restartTextCanvas;
	private bool restart;
	public GameObject gameOverTextCanvas;
	private bool gameOver;



	//it is called in the first frame when this object is instantiated
	void Start()
	{		

		SetupGui ();
		if (scoreText == null)
		{
			Debug.Log ("Não foi possível instanciar Text");
		}



		StartCoroutine (SpawnWaves ());


	}


	void Update()
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				Application.LoadLevel (Application.loadedLevel);
			}
				
		}
	}


	//coroutines need to return an IEnumerator
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);//wait time in the start of the game, to the player get ready
		while(true){
			for(int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;//Quaternion.identity means no rotation

				int hazardIndex = Random.Range(0, hazards.Length);//gets one random hazard to instantiate:
				Instantiate (hazards[hazardIndex], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);//coroutine, wait time between new Asteroids
			}	
			yield return new WaitForSeconds (waveWait);//wait time between waves

			if (gameOver)
			{
				restartTextCanvas.GetComponent<Text>().text = "Press 'R' for Restart";
				restart = true;
				break;//goes out of the loop
			}

		}

	}

	//public to be accessed by other scripts
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		if (scoreText != null) 
		{
			UpdateScore ();
		} 
		else 
		{
			Debug.Log ("Couldn't find scoreText(Text) in 'GameController' script");
		}

	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	void SetupGui()
	{
		gameOver = false;
		restart = false;
		score = 0;
		scoreText = scoreTextCanvas.GetComponent<Text>();//gets the Text component from the canvas
		restartTextCanvas.GetComponent<Text>().text = "";
		gameOverTextCanvas.GetComponent<Text>().text = "";
	}

	public void GameOver()
	{
		gameOverTextCanvas.GetComponent<Text> ().text = "Game Over!";
		gameOver = true;
	}

}
