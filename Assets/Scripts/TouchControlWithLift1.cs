using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.EventSystems;
using SkyInnovations;


public class TouchControlWithLift1 : MonoBehaviour
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

	public bool enableCount = true;

	private ObjLogic_SceneB ObjLogic_SceneB;

	private Vector3 originalScale;

	private void OnEnable()
	{
		if (cam == null) cam = Camera.main;
	}

	private void Start()
	{
		originalScale = transform.localScale;
		prevAngle = transform.eulerAngles.y;
		originalY = transform.position.y;
		originalPos = transform.position;
		ObjLogic_SceneB = FindObjectOfType<ObjLogic_SceneB>();
	}

	public void Reset()
	{
		// StopCoroutine(nameof(MoveCoroutine));
		// Debug.Log(originalScale);
		CancelInvoke();
		transform.DOKill();
		transform.position = originalPos;
		StopAllCoroutines();
		transform.localScale = new Vector3(1, 1, 1);
		// StartCoroutine(MoveCoroutine(new Vector3(1, 1, 1), 1));
		draggable = true;
		droppedInWater = false;
		enableCount = true;
		gameObject.GetComponent<ObjLogic2>().drownable = false;
		if (TryGetComponent<Renderer>(out _))
		{
			GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		}
	}

	//есть одно касание и не начали корутину перетаскивания - начинаем

	//есть два и не начали вращение-перетаскивание - начнаем

	Vector3 mouseDelta;

	private Coroutine MovingCoroutine;

	bool properlySelected = false;

	private void OnMouseDown()
	{
		///////////////////////////////////////////
		//gameObject.transform.DOScale(3f,1f).SetEase(Ease.OutBack);
		//gameObject.transform.localScale = new Vector3(3,3,3);

		if (Utilities.IsPointerOverUIObject() || EventSystem.current.IsPointerOverGameObject() || !draggable) return;

		MovingCoroutine = StartCoroutine(MoveCoroutine(new Vector3(3, 3, 3), 100));

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

	IEnumerator MoveCoroutine(Vector3 scaleTo, int time = 100)
	{
		while (transform.localScale != scaleTo)
		{
			// Debug.Log("coroutine");
			transform.localScale += (scaleTo - transform.localScale) / time;
			yield return null;
		}
		yield break;

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
		///////////////////////////////////////////
		//gameObject.transform.DOScale(1f, 1f).SetEase(Ease.OutBack);
		//gameObject.transform.localScale = new Vector3(1, 1, 1);

		StopCoroutine(MovingCoroutine);
		StartCoroutine(MoveCoroutine(new Vector3(1, 1, 1), 10));

		Debug.Log("mouse up");
		if (!properlySelected) return;

		//print("OnMouseUp");
		bRotating = false;
		objPlane = default(Plane);

		if (isInDropZone)
		{
			droppedInWater = true;
			Debug.Log("drop zone");
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
		if (TryGetComponent<Renderer>(out _))
		{
			GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		}
	}

	private void LandedToWater()
	{
		Debug.Log("Landed to water");
		//всплеск
		GetComponent<AudioSource>().Play();

		//objLogic_Scenario2.ObjectThrownToWater();

		if (GetComponent<ObjLogic2>().drownable)
		{
			Debug.Log("is drownable");
			//идёт на дно до того как не коснётся его
			transform.DOMoveY(dnoY, 1).SetSpeedBased(true);
			// убираем тень у всех дочерних элементов
			for (int i = 0; i < gameObject.transform.childCount; i++)
			{
				Debug.Log("Shadow offset");
				if (gameObject.transform.GetChild(i).GetComponent<Renderer>())
				{
					gameObject.transform.GetChild(i).GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
				}

				for (int j = 0; j < gameObject.transform.GetChild(i).transform.childCount; j++)
                {
					if (gameObject.transform.GetChild(i).transform.GetChild(j).GetComponent<Renderer>())
					{
						gameObject.transform.GetChild(i).transform.GetChild(j).GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
					}
				}
			}
			//gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<>
		}
		else
		{
			Debug.Log("is not drownable");
			//остаётся плавать
			transform.DOMoveY(transform.position.y + 0.2f, 0.8f).SetLoops(-1, LoopType.Yoyo);
			//objLogic_Scenario1.ObjectThrownToWater();
			//ObjLogic_SceneB.ObjectThrownToWater();
			if (enableCount)
				ObjLogic_SceneB.ObjectThrownToWater();
			enableCount = false;
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
		//ObjLogic_SceneB.ObjectThrownToWater();
		if (enableCount)
			ObjLogic_SceneB.ObjectThrownToWater();
		enableCount = false;
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
