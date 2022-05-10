using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLogic_SceneA : MonoBehaviour
{
	public GameObject Wood_Plank;
	public GameObject Wood_Door;
	public GameObject Big_Metal_Plate;
	public GameObject Small_Metal_Plate;
	public GameObject Big_Glass;
	public GameObject Small_Glass;

	public GameObject NamingWindow;

	public static int SelectedHypothesisId;

	int hypothesisObjectsCount; //задаётся, когда выбрана гипотеза
	public int thrownObjectsCount = 0; //счетчик закинутых обьектов

	List<GameObject> objects;

	public bool testing = true;

	private void Start() {
		objects = new List<GameObject>();
		objects.Add(Wood_Plank);
		objects.Add(Wood_Door);
		objects.Add(Big_Metal_Plate);
		objects.Add(Small_Metal_Plate);
		objects.Add(Big_Glass);
		objects.Add(Small_Glass);

		//Names
		Wood_Plank.GetComponent<Scenario1Object>().SetText("Wood plank");
		Wood_Door.GetComponent<Scenario1Object>().SetText("Wood door");
		Big_Metal_Plate.GetComponent<Scenario1Object>().SetText("Big metal plate");
		Small_Metal_Plate.GetComponent<Scenario1Object>().SetText("Small metal plate");
		Big_Glass.GetComponent<Scenario1Object>().SetText("Big glass");
		Small_Glass.GetComponent<Scenario1Object>().SetText("Small glass");

		foreach (GameObject obj in objects)
		{
			obj.GetComponent<Scenario1Object>().Valid = false;
		}
	}

    private void Update()
    {
        if ((Wood_Plank.GetComponent<Scenario1Object>().TestNameLogic == false) 
			&& (Wood_Door.GetComponent<Scenario1Object>().TestNameLogic == false)
			&& (Big_Metal_Plate.GetComponent<Scenario1Object>().TestNameLogic == false)
			&& (Small_Metal_Plate.GetComponent<Scenario1Object>().TestNameLogic == false)
			&& (Big_Glass.GetComponent<Scenario1Object>().TestNameLogic == false)
			&& (Small_Glass.GetComponent<Scenario1Object>().TestNameLogic == false)
			&& this.testing)
		{
			this.testing = false;
			Invoke("MakeHypothesis", 2f);
		}
    }

	private void MakeHypothesis()
	{
		NamingWindow.SetActive(false);
		FindObjectOfType<Logic_Scenario1>().StartFirstScene();
		foreach (GameObject obj in objects)
		{
			obj.GetComponent<Scenario1Object>().TestName = false;
		}
	}

	public void ResetExperiment()
	{
		//this.testing = false;
		foreach (GameObject obj in objects)
		{
			obj.SendMessage("Reset"); //reset position (and state)
			obj.GetComponent<Scenario1Object>().Valid = false;
			obj.GetComponent<Scenario1Object>().TestName = false;
			obj.GetComponent<Scenario1Object>().TestNameLogic = false;
			obj.GetComponent<TouchControlWithLift>()._counted = false;
		}
	}

	public void ResetTestingName()
	{
		this.testing = true;
		foreach (GameObject obj in objects)
		{
			obj.GetComponent<Scenario1Object>().TestName = true;
			obj.GetComponent<Scenario1Object>().TestNameLogic = true;
			obj.GetComponent<Scenario1Object>().ShowArrow();
		}
	}

	public void SetSelectedHypothesisId(int id)
	{
		SelectedHypothesisId = id;

		foreach (GameObject obj in objects) {
			obj.SendMessage("Reset"); //reset position (and state)
			obj.GetComponent<Scenario1Object>().Valid = false;
			obj.GetComponent<Scenario1Object>().HideArrow();
		}

		thrownObjectsCount = 0;


		switch (id)
		{

			case 0:
				Big_Metal_Plate.GetComponent<Scenario1Object>().Valid = true;
				Big_Metal_Plate.GetComponent<Scenario1Object>().ShowArrow();
				Wood_Door.GetComponent<Scenario1Object>().Valid = true;
				Wood_Door.GetComponent<Scenario1Object>().ShowArrow();
				Big_Glass.GetComponent<Scenario1Object>().Valid = true;
				Big_Glass.GetComponent<Scenario1Object>().ShowArrow();
				hypothesisObjectsCount = 3;
				break;

			case 1:
				Wood_Plank.GetComponent<Scenario1Object>().Valid = true;
				Wood_Plank.GetComponent<Scenario1Object>().ShowArrow();
				Small_Metal_Plate.GetComponent<Scenario1Object>().Valid = true;
				Small_Metal_Plate.GetComponent<Scenario1Object>().ShowArrow();
				Small_Glass.GetComponent<Scenario1Object>().Valid = true;
				Small_Glass.GetComponent<Scenario1Object>().ShowArrow();
				hypothesisObjectsCount = 3;
				break;

			case 2:
				Big_Metal_Plate.GetComponent<Scenario1Object>().Valid = true;
				Big_Metal_Plate.GetComponent<Scenario1Object>().ShowArrow();
				Small_Metal_Plate.GetComponent<Scenario1Object>().Valid = true;
				Small_Metal_Plate.GetComponent<Scenario1Object>().ShowArrow();
				hypothesisObjectsCount = 2;
				break;

			case 3:
				Wood_Plank.GetComponent<Scenario1Object>().Valid = true;
				Wood_Plank.GetComponent<Scenario1Object>().ShowArrow();
				Wood_Door.GetComponent<Scenario1Object>().Valid = true;
				Wood_Door.GetComponent<Scenario1Object>().ShowArrow();
				hypothesisObjectsCount = 2;
				break;

			case 4:
				Big_Glass.GetComponent<Scenario1Object>().Valid = true;
				Big_Glass.GetComponent<Scenario1Object>().ShowArrow();
				Small_Glass.GetComponent<Scenario1Object>().Valid = true;
				Small_Glass.GetComponent<Scenario1Object>().ShowArrow();
				hypothesisObjectsCount = 2;
				break;
		}

	}


	private float someDelayBeforeResult = 1.5f;

	private void ShowResult() {
		FindObjectOfType<Logic_Scenario1>().ExperimentResult();
	}

	public void ObjectThrownToWater()
	{
		print("ThrownToWater: "+ thrownObjectsCount + " out of "+ hypothesisObjectsCount);
		thrownObjectsCount++;
		if (thrownObjectsCount == hypothesisObjectsCount)
		{
			Invoke("ShowResult", someDelayBeforeResult);
		}
	}
}
