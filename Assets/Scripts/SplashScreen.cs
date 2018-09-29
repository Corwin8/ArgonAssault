using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {



	// Use this for initialization

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	void Start ()
	{
		Invoke("LoadLevel", 2f);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void LoadLevel()
	{
		SceneManager.LoadScene(1);
	}
}
