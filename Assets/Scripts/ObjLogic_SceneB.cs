using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLogic_SceneB : MonoBehaviour
{
    public GameObject Big_Metal_Conatiner;
    public GameObject Small_Metal_Conatiner;
    public GameObject Big_Glass_Conatiner;
    public GameObject Small_Glass_Conatiner;

    public GameObject Big_Metal;
    public GameObject Small_Metal;
    public GameObject Big_Glass;
    public GameObject Small_Glass;

    public GameObject Big_Metal_Hole_Sphere;
    public GameObject Small_Metal_Hole_Sphere;
    public GameObject Big_Glass_Hole_Sphere;
    public GameObject Small_Glass_Hole_Sphere;

    public GameObject Big_Metal_Curved;
    public GameObject Small_Metal_Curved;
    public GameObject Big_Glass_Curved;
    public GameObject Small_Glass_Curved;

    public GameObject Big_Metal_SemiSphere;
    public GameObject Small_Metal_SemiSphere;
    public GameObject Big_Glass_SemiSphere;
    public GameObject Small_Glass_SemiSphere;

    List<GameObject> objects;

    //public GameObject Big_Glass_Sphere;

    public int SelectedHypothesisId;


    int hypothesisObjectsCount = 4; //задаётся, когда выбрана гипотеза
    public int thrownObjectsCount = 0; //счетчик закинутых обьектов

    void Start()
    {
        objects = new List<GameObject>();
        /*
        objects.Add(Big_Metal);
        objects.Add(Small_Metal);
        objects.Add(Big_Glass);
        objects.Add(Small_Glass);
        */

        objects.Add(Big_Metal_Hole_Sphere);
        objects.Add(Small_Metal_Hole_Sphere);
        objects.Add(Big_Glass_Hole_Sphere);
        objects.Add(Small_Glass_Hole_Sphere);

        objects.Add(Big_Metal_Curved);
        objects.Add(Small_Metal_Curved);
        objects.Add(Big_Glass_Curved);
        objects.Add(Small_Glass_Curved);

        objects.Add(Big_Metal_SemiSphere);
        objects.Add(Small_Metal_SemiSphere);
        objects.Add(Big_Glass_SemiSphere);
        objects.Add(Small_Glass_SemiSphere);
    }

    public void OnObjectClick(int objId)
    {
        switch (objId)
        {
            case 0:
                Big_Metal.SetActive(false);
                if (SelectedHypothesisId == 0)
                {
                    Big_Metal_Hole_Sphere.SetActive(true);
                }
                if (SelectedHypothesisId == 1)
                {
                    Big_Metal_Curved.SetActive(true);
                }
                if (SelectedHypothesisId == 2)
                {
                    Big_Metal_Conatiner.GetComponent<ObjLogic2>().drownable = true;
                    Big_Metal_SemiSphere.SetActive(true);
                }
                break;
            case 1:
                Small_Metal.SetActive(false);
                if (SelectedHypothesisId == 0)
                {
                    Small_Metal_Hole_Sphere.SetActive(true);
                }
                if (SelectedHypothesisId == 1)
                {
                    Small_Metal_Curved.SetActive(true);
                }
                if (SelectedHypothesisId == 2)
                {
                    Small_Metal_Conatiner.GetComponent<ObjLogic2>().drownable = true;
                    Small_Metal_SemiSphere.SetActive(true);
                }
                break;
            case 2:
                Big_Glass.SetActive(false);
                if (SelectedHypothesisId == 0)
                {
                    Big_Glass_Hole_Sphere.SetActive(true);
                }
                if (SelectedHypothesisId == 1)
                {
                    Big_Glass_Curved.SetActive(true);
                }
                if (SelectedHypothesisId == 2)
                {
                    Big_Glass_Conatiner.GetComponent<ObjLogic2>().drownable = true;
                    Big_Glass_SemiSphere.SetActive(true);
                }
                break;
            case 3:
                Small_Glass.SetActive(false);
                if (SelectedHypothesisId == 0)
                {
                    Small_Glass_Hole_Sphere.SetActive(true);
                }
                if (SelectedHypothesisId == 1)
                {
                    Small_Glass_Curved.SetActive(true);
                }
                if (SelectedHypothesisId == 2)
                {
                    Small_Glass_Conatiner.GetComponent<ObjLogic2>().drownable = true;
                    Small_Glass_SemiSphere.SetActive(true);
                }
                break;
        }
    }

    public void ObjectThrownToWater()
    {
        Debug.Log("ThrownToWater: " + thrownObjectsCount + " out of " + hypothesisObjectsCount);
        thrownObjectsCount++;
        if (thrownObjectsCount == hypothesisObjectsCount)
        {
            Invoke(nameof(ShowResult), 1.5f);
        }
    }

    private void ShowResult()
    {
        FindObjectOfType<Logic_Scenario1>().ExperimentResult();
    }

    public void ResetExperiment()
    {
        hypothesisObjectsCount = 4;
        thrownObjectsCount = 0;
        Big_Metal_Conatiner.GetComponent<TouchControlWithLift1>().Reset();
        Small_Metal_Conatiner.GetComponent<TouchControlWithLift1>().Reset();
        Big_Glass_Conatiner.GetComponent<TouchControlWithLift1>().Reset();
        Small_Glass_Conatiner.GetComponent<TouchControlWithLift1>().Reset();
        foreach (GameObject obj in objects)
        {
            //obj.SendMessage("Reset");
            obj.SetActive(false);
        }
        // включаем тени
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].GetComponent<Renderer>())
            {
                objects[i].GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }

            for (int j = 0; j < objects[i].transform.childCount; j++)
            {
                if (objects[i].transform.GetChild(j).GetComponent<Renderer>())
                {
                    objects[i].transform.GetChild(j).GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
            }
        }
        Big_Metal.SetActive(true);
        Small_Metal.SetActive(true);
        Big_Glass.SetActive(true);
        Small_Glass.SetActive(true);
    }

    public void SetSelectedHypothesisId(int id)
    {
        SelectedHypothesisId = id;
        thrownObjectsCount = 0;
    }
}
