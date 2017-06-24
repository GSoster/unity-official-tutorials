using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//se encontrar player, ativa powerUp no player, desativa a si mesmo.
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		if (other.tag == "Player") 
		{
			//#################################
			//SHIELD ONLY
			Destroy(gameObject);//destroi o powerup que o player pegou
			//adiciona um valor ao escudo do player
			var player = GameObject.FindGameObjectWithTag ("Player");
			var playerScript = (PlayerController)player.GetComponent (typeof (PlayerController));
			playerScript.shieldValue += 0.5f;

			//GameObject.FindGameObjectWithTag("Player_PowerUp_Shield").GetComponent<ParticleSystem>().enableEmission = true;//ativa a emissao de particulas do powerup do player
			//As linhas de baixo sao equivalentes a de cima, apenas sao voltadas para a versao mais nova da unity. explicacao aqui: https://forum.unity3d.com/threads/enabling-emission.364258/
			ParticleSystem ps = GameObject.FindGameObjectWithTag ("Player_PowerUp_Shield").GetComponent<ParticleSystem> ();
			ParticleSystem.EmissionModule emissionModule = ps.emission;
			emissionModule.enabled = true;

			//ativa um valor para o TAMANHO das particulas do escudo
			ParticleSystem.MainModule psMain = ps.main;
			psMain.startSize = playerScript.shieldValue;

			//gameController.AddScore (scoreValue);//powerUps dão pontos?
			//#################################
			// END OF SHIELD ONLY
		}
	}
}
