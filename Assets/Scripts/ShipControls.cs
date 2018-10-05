using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipControls : MonoBehaviour {

	[Header("General")]
	[Tooltip("In ms^-1")][Range(0, 8)] [SerializeField] float controlSpeed = 8f;
	[Range(0, 5)] [SerializeField] float maxXOffset = 4f;
	[Range(0, 5)] [SerializeField] float maxYOffset = 3f;
	bool controlsEnabled = true;

	[Header("Position-based controls")]
	[SerializeField] float positionPitchFactor = -5f;
	[SerializeField] float positionYawFactor = 5f;

	[Header("Throw-based controls")]
	[SerializeField] float controlPitchFactor = -30f;
	[SerializeField] float controlRollFactor = -30f;


	float xThrow, yThrow;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (controlsEnabled)
		{
			ProcessTranslation();
			ProcessRotation();
		}
	}

	private void ProcessRotation()
	{
		float pitch = transform.localPosition.y * positionPitchFactor + yThrow*controlPitchFactor;
		float yaw = transform.localPosition.x * positionYawFactor;
		float roll = xThrow * controlRollFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void ProcessTranslation()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * controlSpeed * Time.deltaTime;
		float yOffset = yThrow * controlSpeed * Time.deltaTime;

		float rawXPos = transform.localPosition.x + xOffset;
		float rawYPos = transform.localPosition.y + yOffset;
		float clampedXPos = Mathf.Clamp(rawXPos, -maxXOffset, maxXOffset);
		float clampedYPos = Mathf.Clamp(rawYPos, -maxYOffset, maxYOffset);

		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}

	private void DisableControls()  //called by string reference
	{
		controlsEnabled = false;
	}
}
