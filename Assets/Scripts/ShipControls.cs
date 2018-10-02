using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipControls : MonoBehaviour {

	[Tooltip("In ms^-1")][Range(0, 8)] [SerializeField] float universalSpeed = 2f;
	[Range(0, 5)] [SerializeField] float maxXOffset = 3f;
	[Range(0, 5)] [SerializeField] float maxYOffset = 2f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * universalSpeed * Time.deltaTime;
		float yOffset = yThrow * universalSpeed * Time.deltaTime;

		float rawXPos = transform.localPosition.x + xOffset;
		float rawYPos = transform.localPosition.y + yOffset;
		float clampedXPos = Mathf.Clamp(rawXPos, -maxXOffset, maxXOffset);
		float clampedYPos = Mathf.Clamp(rawYPos, -maxYOffset, maxYOffset);

		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}
}
