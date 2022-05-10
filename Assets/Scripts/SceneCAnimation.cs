using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class SceneCAnimation : MonoBehaviour
{
    public GameObject sceneC;
    public GameObject scenarioLogic;
    public GameObject sceneCCanvas;

    public Transform earthPivot;
    public TMP_Text SceneCDate;

    private float earthPivotRotation;
    private DateTime currentDate = new DateTime(2020, 1, 1, 0, 0, 0);

    void Start()
    {
        SceneCDate.text = currentDate.ToString("dd", CultureInfo.CreateSpecificCulture("en-US")) + " " +
            Lean.Localization.LeanLocalization.GetTranslationText(currentDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")));
    }

    public void resetExperiment()
    {
        earthPivotRotation = 0;
        earthPivot.localEulerAngles = new Vector3(0, 0, 0);
        currentDate = new DateTime(2020, 1, 1, 0, 0, 0);
        SceneCDate.text = currentDate.ToString("dd", CultureInfo.CreateSpecificCulture("en-US")) + " " +
            Lean.Localization.LeanLocalization.GetTranslationText(currentDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")));
    }

    public void SetEarthPivotRotation(bool b)
    {
        if (b)
        {
            InvokeRepeating("RotateAroundSun", 0, 0.02f);
        }
        else
        {
            CancelInvoke("RotateAroundSun");
        }
    }

    private void StepRotate(Transform t, float step)
    {
        if (earthPivotRotation < 360)
        {
            earthPivotRotation += step;
            t.localEulerAngles = new Vector3(0, earthPivotRotation, 0);
            currentDate = currentDate.AddDays(1);
            SceneCDate.text = currentDate.ToString("dd", CultureInfo.CreateSpecificCulture("en-US")) + " " +
                Lean.Localization.LeanLocalization.GetTranslationText(currentDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")));
        }
        else
        {
            scenarioLogic.GetComponent<Logic_Scenario2>().WindowsTransition(1);
            sceneCCanvas.SetActive(false);
            earthPivotRotation = 0;
            CancelInvoke("RotateAroundSun");
        }
    }

    private void RotateAroundSun()
    {
        StepRotate(earthPivot, 1);
    }
}
