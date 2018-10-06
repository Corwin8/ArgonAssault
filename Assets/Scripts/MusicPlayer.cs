using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization

	void Awake()
	{
		int numOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

		if (numOfMusicPlayers > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	void Start ()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
