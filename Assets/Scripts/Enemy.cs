using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject enemyDeathFX;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerEnemy = 12;
	[SerializeField] int enemyHP = 100;

	ShipControls shipControls;
	GameObject playerShip;
	ScoreBoard scoreBoard;

	GameObject deathFX;
	Collider enemyCollider;
	
	// Use this for initialization
	void Start ()
	{
		GetReferenceToPlayerDamage();
		AddNonTriggerBoxCollider();
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}

	private void GetReferenceToPlayerDamage()
	{
		playerShip = GameObject.Find("PlayerShip");
		shipControls = playerShip.GetComponent<ShipControls>();
	}

	private void AddNonTriggerBoxCollider()
	{
		enemyCollider = gameObject.AddComponent<MeshCollider>();
		enemyCollider.isTrigger = false;
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void OnParticleCollision(GameObject other)
	{
		ProcessHit();
		if (enemyHP <= 0)
		{
			KillEnemy();
		}
	}

	private void ProcessHit()
	{
		enemyHP = enemyHP - shipControls.playerWeaponDamage;
	}

	private void KillEnemy()
	{
		deathFX = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
		deathFX.transform.parent = parent;
		scoreBoard.SetScore(scorePerEnemy);
		Destroy(gameObject);
	}
}
