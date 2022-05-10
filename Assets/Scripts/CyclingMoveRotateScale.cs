using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CyclingMoveRotateScale : MonoBehaviour {

	public Vector3 moveBy = new Vector3(0, 0, 0);
	public Vector3 rotateBy = new Vector3(0, 0, 0);
	public Vector3 scaleBy = new Vector3(0,0,0);

	private Vector3 originalPos;
	private Vector3 originalRot;
	private Vector3 originalScale;

	public float halfCycleTime = 1f;
	public bool randomizeTime = false;
	public float minTime = 0.5f;
	public float maxTime = 1.5f;

	public Ease easing = Ease.InOutSine;

	// Use this for initialization
	void Start () {

	originalPos = transform.localPosition;
	originalRot = transform.localEulerAngles;
	originalScale = transform.localScale;

	transform.DOLocalMove(originalPos + moveBy, halfCycleTime).SetEase(easing).SetLoops(-1, LoopType.Yoyo);
	transform.DOScale(originalScale+scaleBy, halfCycleTime).SetEase(easing).SetLoops(-1, LoopType.Yoyo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
