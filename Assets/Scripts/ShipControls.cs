using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipControls : MonoBehaviour {

	[Tooltip("In ms^-1")][Range(0, 8)] [SerializeField] float xSpeed = 2f;
	[Range(0, 5)] [SerializeField] float maxXOffset = 3f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

		float xOffset = xThrow * xSpeed * Time.deltaTime;
		float rawXPos = transform.localPosition.x + xOffset;
		float pos = Mathf.Clamp(rawXPos, -maxXOffset, maxXOffset);

		transform.localPosition = new Vector3(pos, transform.localPosition.y, transform.localPosition.z);
	}
}
