using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	//this script allows the enemy to shoot
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;//0.5 means shoot 2 times every second... 1 means 1 shot per second, etc
	public float waitTime;//a time to the player gets ready

	private AudioSource audioSource;//sound from the shot/bolt

	// Use this for initialization
	void Start () 
	{
		audioSource = GetComponent<AudioSource >();
		//InvokeRepeating = Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
		InvokeRepeating("Fire", waitTime, fireRate);
	}
		

	void Fire()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		audioSource.Play ();
	}
}
