using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	//this script allows the enemy to shoot
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	public float waitTime;//a time to the player gets ready
	public bool shouldShoot;

	private AudioSource audioSource;//sound from the shot/bolt

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource >();
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		//while (shouldShoot) {
			if (Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				//audioSource.Play ();
			}
		//}
	}
}
