using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

	float restartDelay = 2f;
	[SerializeField] GameObject deathFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
	}

	private void StartDeathSequence()
	{
		print("Player dying.");
		SendMessage("DisableControls");
		deathFX.SetActive(true);
		Invoke("RestartAfterDeath", restartDelay);
	}

	private void RestartAfterDeath() //called by string reference
	{
		SceneManager.LoadScene(0);
	}

}
