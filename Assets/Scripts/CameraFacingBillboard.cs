using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
	public Camera cam;
	//public float objectScale = 1.0f;
	//private Vector3 initialScale;

	public bool bReverseForward = true;

	public bool lockX = false;
	public bool lockY = false;
	public bool lockZ = false;

	private Vector3 originalEulers;

	private Vector3 forwardVector;

	void Awake()
	{

		// record initial scale, use this as a basis
		//initialScale = transform.localScale;

		// if no camera referenced, grab the main camera
		if (!cam)
			cam = Camera.main;

		Vector3 originalEulers = transform.rotation.eulerAngles;

		if (bReverseForward) forwardVector = Vector3.forward;
		else forwardVector = -Vector3.forward;
	}

	void Update()
	{
		//Plane plane = new Plane(cam.transform.forward, cam.transform.position);
		//float dist = plane.GetDistanceToPoint(transform.position);
		//transform.localScale = initialScale * dist * objectScale;

		transform.LookAt(transform.position + cam.transform.rotation * forwardVector, cam.transform.rotation * Vector3.up);

		Vector3 newRotation = transform.rotation.eulerAngles;

		if (lockX) newRotation.x = originalEulers.x;
		if (lockY) newRotation.y = originalEulers.y;
		if (lockZ) newRotation.z = originalEulers.z;

		transform.rotation = Quaternion.Euler(newRotation);
	}
}
