using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject enemyDeathFX;
	[SerializeField] Transform parent;

	GameObject deathFX;
	Collider enemyCollider;
	
	// Use this for initialization
	void Start ()
	{
		AddNonTriggerBoxCollider();
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
		deathFX = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
		deathFX.transform.parent = parent;
		Destroy(gameObject);
	}
}
