using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppearAnimated : MonoBehaviour
{
	private void OnEnable() {		
		transform.DOScale(0.4f, 0.6f).From().SetEase(Ease.OutBack);
	}
}
