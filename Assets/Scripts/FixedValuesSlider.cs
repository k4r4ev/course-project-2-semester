using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class FixedValuesSlider : MonoBehaviour {


	//private void Awake() {

	//}

	public GameObject messageReceiver;
	public float[] fixedValues = { 0.125f, 0.25f, 0.5f, 0.75f, 1f};
	
	private Slider slider;

	private float curSliderValue;
	private float curFixedValue;

	// Use this for initialization
	void Start () {

		curFixedValue = 1;

		slider = GetComponent<Slider>();
		slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
		//slider.onValueChanged.AddListener(fractionsSliderValueChanged);
	}

	public float closestNumberInArray(float target, float[] collection) {
		// NB Method will return int.MaxValue for a sequence containing no elements.
		// Apply any defensive coding here as necessary.
		float closest = float.MaxValue;
		float minDifference = float.MaxValue;

		foreach (float element in collection) {
			//print(element);
			float difference = Mathf.Abs(element - target);
			if (minDifference > difference) {
				minDifference = difference;
				closest = element;
			}
		}

		return closest;
	}

	private void changeCurFixedValue(float newFixedValue) {
		curFixedValue = newFixedValue;
		try {
			messageReceiver.SendMessage("fractionsSliderValueChanged", curFixedValue);
		}
		catch { }
	}

	public void ValueChangeCheck() {
		//Debug.Log("ValueChangeCheck:"+slider.value);
		//slider.value = 0.5f;
		//float nearest = array.MinBy(x => Math.Abs((long)x - targetNumber));
		curSliderValue = slider.value;
		float closest = closestNumberInArray(curSliderValue, fixedValues);
		if(closest!= curFixedValue) {
			//curFixedValue = closest;
			changeCurFixedValue(closest);
		}
		slider.value = closest;
		//print(closest);
	}

	//public void fractionsSliderValueChanged(float f) {
	//	print("ValueChanged: "+f);
	//}

}
