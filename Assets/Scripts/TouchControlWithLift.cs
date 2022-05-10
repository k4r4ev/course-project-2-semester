using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.EventSystems;
using SkyInnovations;


public class TouchControlWithLift : MonoBehaviour
{

	public float maxDistanceFromCamera = 10f; //clipping plane actually

	Plane objPlane;

	//private bool bDragging = false;
	private bool bRotating = false;

	public bool rotationEnabled = true;

	private Vector3 originalPos;
	private float originalY;
	public float cursorOffsetY = 0;

	public float dropZoneY;
	public float dnoY;

	public Camera cam;

	private float prevAngle;

	public bool draggable = true;

	public bool _counted = false;

	private ObjLogic_SceneA objLogic_SceneA;

	private void OnEnable()
	{
		if (cam == null) cam = Camera.main;
	}

	private void Start()
	{
		prevAngle = transform.eulerAngles.y;
		originalY = transform.position.y;
		originalPos = transform.position;

		//objLogic_Scenario1 = GameObject.FindGameObjectWithTag();
		objLogic_SceneA = FindObjectOfType<ObjLogic_SceneA>();
	}

	public void Reset()
	{
		CancelInvoke();
		transform.DOKill();
		transform.position = originalPos;
		draggable = true;
		droppedInWater = false;
		GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
	}

	//есть одно касание и не начали корутину перетаскивания - начинаем

	//есть два и не начали вращение-перетаскивание - начнаем

	Vector3 mouseDelta;

	bool properlySelected = false;

	private void OnMouseDown()
	{

		if (Utilities.IsPointerOverUIObject() || EventSystem.current.IsPointerOverGameObject() || !draggable) return;

		DOTween.Kill(transform);

		properlySelected = true;

		print("MouseDown " + gameObject.name);
		//StartCoroutine("DragObject");
		objPlane = new Plane(Vector3.up, transform.position);
		ReCalculateMouseDelta();
		prevAngle = transform.eulerAngles.y;

        //GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        if (TryGetComponent<Renderer>(out _))
		{
			GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
	}

	void ReCalculateMouseDelta()
	{
		objPlane = new Plane(Vector3.up, transform.position);
#if UNITY_EDITOR
		var ray = cam.ScreenPointToRay(Input.mousePosition);
#else
			var ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
#endif
		float distance;
		objPlane.Raycast(ray, out distance);
		var newPos = ray.GetPoint(distance);
		mouseDelta = transform.position - newPos;
	}


	float returnDuration = 1f;
	float dropDuration = 0.7f;


	private void OnMouseUp()
	{

		if (!properlySelected) return;

		//print("OnMouseUp");
		bRotating = false;
		objPlane = default(Plane);

		if (isInDropZone)
		{
			droppedInWater = true;
			//drop
			//Vector3 newPos = transform.position;
			//newPos.y = dropZoneY;
			draggable = false;
			transform.DOLocalMoveY(dropZoneY, dropDuration).SetEase(Ease.InCubic).OnComplete(LandedToWater);
			//transform.position = newPos;
		}
		else
		{
			//go to original position
			//transform.position = originalPos;
			transform.DOMove(originalPos, returnDuration).SetEase(Ease.OutQuad).OnComplete(ReturnedToOriginalPos);
		}

		properlySelected = false;
	}

	//
	private void ReturnedToOriginalPos()
	{
		GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
	}

	private void LandedToWater()
	{
		Debug.Log("Landed to water");
		//всплеск
		GetComponent<AudioSource>().Play();
		//objLogic_Scenario1.ObjectThrownToWater();

		if (GetComponent<Scenario1Object>().drownable)
		{
			//идёт на дно до того как не коснётся его
			transform.DOMoveY(dnoY, 1).SetSpeedBased(true);
		}
		else
		{
			//остаётся плавать
			transform.DOMoveY(transform.position.y + 0.2f, 0.8f).SetLoops(-1, LoopType.Yoyo);
			_counted = true;
			if (_counted)
				objLogic_SceneA.ObjectThrownToWater();
			//objLogic_Scenario2.ObjectThrownToWater();
		}
	}


	private void OnMouseDrag()
	{

		if (!properlySelected) return;

		objPlane = new Plane(Vector3.up, transform.position);

#if UNITY_EDITOR
		var ray = cam.ScreenPointToRay(Input.mousePosition);
#else
			var ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
#endif

		float distance;
		objPlane.Raycast(ray, out distance);

		var newPos = ray.GetPoint(distance);

		newPos = newPos + mouseDelta;
		Vector3 camPos = cam.transform.position;
		/*clampedPosition.x = Mathf.Clamp(clampedPosition.x, camPos.x - maxDistanceFromCamera, camPos.x + maxDistanceFromCamera);
		clampedPosition.y = transform.position.y;
		clampedPosition.z = Mathf.Clamp(clampedPosition.z, camPos.z - maxDistanceFromCamera, camPos.z + maxDistanceFromCamera);
		*/

		// Calculate the distance of the new position from the center point. Keep the direction
		// the same but clamp the length to the specified radius.
		Vector3 offset = newPos - camPos;
		newPos = camPos + Vector3.ClampMagnitude(offset, maxDistanceFromCamera);

		newPos.y = originalY + cursorOffsetY;
		transform.position = newPos;

		//transform.position = clampedPosition;

		if (Input.touchCount > 1 && rotationEnabled)
		{

			float newAngle = GetTouchesAngle();
			//if (newAngle < 180) newAngle += 180;

			if (!bRotating)
			{
				bRotating = true;
			}
			else
			{
				//print("new: " + newAngle + " prev:" + prevAngle + " delta=" + (newAngle - prevAngle));
				if (newAngle < 0 && prevAngle > 0) prevAngle *= -1;
				if (newAngle > 0 && prevAngle < 0) prevAngle *= -1;
				float deltaAngle = newAngle - prevAngle;
				/*if (deltaAngle < -180) deltaAngle += 180;
				else if (deltaAngle > 180) deltaAngle -= 180;
				else if(deltaAngle<-90) deltaAngle += 90;
				else if (deltaAngle > 90) deltaAngle -= 90;
				*/
				transform.Rotate(Vector3.up, deltaAngle);
			}

			prevAngle = newAngle;

		}
		else
		{
			if (!bRotating) bRotating = false;
			//ReCalculateMouseDelta();
		}

	}

	float GetTouchesAngle()
	{

		//if (Input.touchCount < 2) return 0;

		float dx = Input.GetTouch(0).position.x - Input.GetTouch(1).position.x;
		float dy = Input.GetTouch(0).position.y - Input.GetTouch(1).position.y;

		return Mathf.Atan(dx / dy) * 180 / Mathf.PI;

	}


	public Collider dropZoneCollider;
	private bool isInDropZone;
	private bool droppedInWater;
	public Collider dnoCollider;

	private void OnTriggerEnter(Collider other)
	{
		if (other == dropZoneCollider)
		{
			print(gameObject.name + " enters Drop Zone");
			isInDropZone = true;
		}
		else if (other == dnoCollider && droppedInWater)
		{
			Invoke("KillTween", 0.3f);
			//KillTween();
		}
	}

	void KillTween()
	{
		transform.DOKill();
		Debug.Log("killtwin");
		_counted = true;
		if (_counted)
			objLogic_SceneA.ObjectThrownToWater();
	}

	private void OnTriggerExit(Collider other)
	{
		if (other == dropZoneCollider)
		{
			isInDropZone = false;
			print(gameObject.name + " exits Drop Zone");
		}
	}

	//private void OnTriggerStay(Collider other) {
	//	if (other == dnoCollider) {
	//		transform.DOKill();
	//	}
	//}


	//public bool CheckIfDropIsAcceptable() {

	//}
}
