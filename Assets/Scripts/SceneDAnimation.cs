using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class SceneDAnimation : MonoBehaviour
{
    public GameObject sceneD;
    public GameObject scenarioLogic;
    public GameObject sceneDCanvas;

    public Transform earth;
    public TMP_Text SceneDTime;

    private float earthPivotRotation = 0;

    private DateTime currentDate = new DateTime(2020, 1, 1, 0, 0, 0);

    void Start() { }


    public void resetExperiment()
    {
        earthPivotRotation = 0;
        earth.localEulerAngles = new Vector3(0, 0, 0);
        currentDate = new DateTime(2020, 1, 1, 0, 0, 0);
        SceneDTime.text = "00 00";  //currentDate.ToString("hh mm", CultureInfo.CreateSpecificCulture("en-US"));
    }

    public void EarthRotation()
    {
        InvokeRepeating("RotateAroundSelf", 0, 0.05f);
    }

    private float earthRotateSpeedHours = 0.25f;

    public void SetEarthRotation(bool b)
    {
        if (b)
        {
            InvokeRepeating("RotateAroundSelf", 0, 0.05f);
        }
        else
        {
            CancelInvoke("RotateAroundSelf");
        }
    }

    private void StepRotate(Transform t, float step)
    {
        if (earthPivotRotation < 360)
        {
            earthPivotRotation += step;
            t.localEulerAngles = new Vector3(0, earthPivotRotation, 0);
            currentDate = currentDate.AddHours(earthRotateSpeedHours);
            SceneDTime.text = currentDate.ToString("HH mm", CultureInfo.CreateSpecificCulture("en-US"));
        }
        else
        {
            resetExperiment();
            CancelInvoke("RotateAroundSelf");
            sceneDCanvas.SetActive(false);
            scenarioLogic.GetComponent<Logic_Scenario2>().WindowsTransition(1);
        }
    }

    private void RotateAroundSelf()
    {
        StepRotate(earth, 360 * earthRotateSpeedHours / 24);
    }
}
