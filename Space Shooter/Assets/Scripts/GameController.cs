using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	//this script is responsible for spawning the hazards

	public GameObject hazard;
	public Vector3 spawnValues;
	public float hazardCount;
	public float spawnWait;//wait time between one spawn hazard and another
	public float startWait;//wait time when the game first start so the player can get ready;
	public float waveWait;//how much time we await between waves



	public GUIText scoreText;//to display the score
	private int score;

	//it is called in the first frame when this object is instantiated
	void Start(){
		score = 0;
		scoreText =  GetComponent<GUIText>();
		StartCoroutine (SpawnWaves ());


	}

	//coroutines need to return an IEnumerator
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);//wait time in the start of the game, to the player get ready
		while(true){
			for(int i = 0; i < hazardCount; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;//Quaternion.identity means no rotation
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);//coroutine, wait time between new Asteroids
			}	
			yield return new WaitForSeconds (waveWait);//wait time between waves
		}

	}

	//public to be accessed by other scripts
	public void AddScore(int newScoreValue){
		score += newScoreValue;
		if (scoreText != null) {
			UpdateScore ();
		} else 
		{
			Debug.Log ("Couldn't find scoreText(GUIText) in 'GameController' script");
		}

	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

}
