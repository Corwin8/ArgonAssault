using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipControls : MonoBehaviour {

	[Tooltip("In ms^-1")][Range(0, 8)] [SerializeField] float universalSpeed = 2f;
	[Range(0, 5)] [SerializeField] float maxXOffset = 3f;
	[Range(0, 5)] [SerializeField] float maxYOffset = 2f;
	[SerializeField] float positionPitchFactor = -5f;
	[SerializeField] float controlPitchFactor = -30f;


	float xThrow, yThrow;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		ProcessTranslation();
		ProcessRotation();
	}

	private void ProcessRotation()
	{
		float pitch = transform.localPosition.y * positionPitchFactor + yThrow*controlPitchFactor;
		float yaw = transform.localPosition.x * positionPitchFactor;
		float roll = xThrow * controlPitchFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void ProcessTranslation()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * universalSpeed * Time.deltaTime;
		float yOffset = yThrow * universalSpeed * Time.deltaTime;

		float rawXPos = transform.localPosition.x + xOffset;
		float rawYPos = transform.localPosition.y + yOffset;
		float clampedXPos = Mathf.Clamp(rawXPos, -maxXOffset, maxXOffset);
		float clampedYPos = Mathf.Clamp(rawYPos, -maxYOffset, maxYOffset);

		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}
}
