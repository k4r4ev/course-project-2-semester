using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Globalization;
using Lean;
using Lean.Localization;

public class SceneEAnimation : MonoBehaviour
{
    public GameObject sceneE;
    public GameObject scenarionSelection;
    public GameObject scenarioLogic;
    public GameObject sceneECanvas;
    //public GameObject overlayCanvas;

    public GameObject ContinueTestWindow;
    public GameObject ContinueTestWindow1;
    public GameObject ContinueTestWindow2;
    public GameObject ContinueTestWindow3;
    public GameObject ContinueTestWindow4;

    private GameObject CurrentContinueWindow;

    public Transform earthPivot;
    public Transform earth;

    public TMP_Text SceneETime;
    public TMP_Text SceneEDate;
    public LeanLocalizedTextMeshProUGUI SceneEDateLean;

    private float earthPivotRotation = 3;
    private float earthRotation = 0;

    private float earthPosition = 3; //Чтобы вернуть землю на позицию
    private const float earthPosition2 = 83;
    private const float earthPosition3 = 185;
    private const float earthPosition4 = 266;

    [SerializeField] private bool firstTask = true; //day january
    [SerializeField] private bool secondTask = false; //day march
    [SerializeField] private bool thirdTask = false; //night july
    [SerializeField] private bool forthTask = false; //day september

    private bool _rotationAroundItselfAllowing = true;


    [SerializeField] private DateTime currentDate = new DateTime(2020, 1, 3, 0, 0, 0);

    public void StartButton()
    {
        resetExperiment();
        ContinueTestWindow.SetActive(true);
        ContinueTestWindow1.SetActive(false);
        ContinueTestWindow2.SetActive(false);
        ContinueTestWindow3.SetActive(false);
        ContinueTestWindow4.SetActive(false);
        sceneECanvas.SetActive(false);
        //overlayCanvas.SetActive(false);
        CancelInvoke("RotateAroundSun");
        CurrentContinueWindow = ContinueTestWindow;
    }

    public void resetExperiment()
    {
        currentDate = new DateTime(2020, 1, 3, 0, 0, 0);
        earthRotation = 0;
        earthPivotRotation = 3;
        firstTask = true;
        secondTask = false;
        thirdTask = false;
        forthTask = false;
        earthPosition = 3;
        earth.localEulerAngles = new Vector3(0, -156.87f, 0);
        earthPivot.localEulerAngles = new Vector3(0, 0, 0);
        SceneETime.text = "00 00"; // currentDate.ToString("hh mm", CultureInfo.CreateSpecificCulture("en-US"));
        //SceneEDate.text = currentDate.ToString("d MMMM", CultureInfo.CreateSpecificCulture("en-US"));
        SceneEDate.text = currentDate.ToString("dd", CultureInfo.CreateSpecificCulture("en-US"));
        SceneEDateLean.TranslationName = currentDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"));
    }

    //AROUND ITSELF
    public void SetEarthRotation(bool b)
    {
        if (b && _rotationAroundItselfAllowing)
        {
            InvokeRepeating("RotateAroundSelf", 0, 0.05f);
        }
        else
        {
            CancelInvoke("RotateAroundSelf");
        }
    }

    private float earthRotateSpeedHours = 0.25f;

    private void StepRotate(Transform t, float step)
    {
        if (earthRotation > 360)
        {
            earthRotation -= 360;
        }

        earthRotation += step;
        t.localEulerAngles += new Vector3(0, step, 0);
        currentDate = currentDate.AddHours(earthRotateSpeedHours);
        SceneETime.text = currentDate.ToString("HH mm", CultureInfo.CreateSpecificCulture("en-US"));
        ///
        SceneEDate.text = currentDate.ToString("dd", CultureInfo.CreateSpecificCulture("en-US"));
        SceneEDateLean.TranslationName = currentDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"));

        CheckDate();
    }

    private void RotateAroundSelf()
    {
        StepRotate(earth, 360 * earthRotateSpeedHours / 24);
    }





    //AROUND SUN
    public void SetEarthRotationAroundSun(bool b)
    {
        if (b)
        {
            InvokeRepeating("RotateAroundSun", 0, 0.02f);
        }
        else
        {
            CancelInvoke("RotateAroundSun");
            if (firstTask) //Первая задача - крутить землю вокруг себя, поэтому возвращаем назад
            {
                StayFirstPosition();
            }
            if (secondTask && (earthPivotRotation > earthPosition2)) //Вторая задача
            {
                earthPosition = earthPosition2;
                StayFirstPosition();
            }
            if (thirdTask && (earthPivotRotation >= earthPosition3)) //Третья задача
            {
                earthPosition = earthPosition3;
                StayFirstPosition();
            }
            if (forthTask && (earthPivotRotation >= earthPosition4)) //Четвертая задача
            {
                earthPosition = earthPosition4;
                StayFirstPosition();
            }
        }
    }

    private void RotateAroundSun()
    {
        StepSunRotate(earthPivot, 1);
    }

    private void RotateToFirstPosition()
    {
        _rotationAroundItselfAllowing = false;
        StepSunRotate(earthPivot, -1);
        if (earthPivotRotation == earthPosition)
        {
            CancelInvoke("RotateToFirstPosition");
            _rotationAroundItselfAllowing = true;
        }
    }

    private void StayFirstPosition()
    {
        InvokeRepeating("RotateToFirstPosition", 0, 0.02f);
    }

    //+WINDOWS LOGIC
    private void StepSunRotate(Transform t, float step)
    {
        earthPivotRotation += step;
        t.localEulerAngles = new Vector3(0, earthPivotRotation, 0);
        currentDate = currentDate.AddDays(step);
        //SceneEDate.text = currentDate.ToString("d MMMM", CultureInfo.CreateSpecificCulture("en-US"));
        SceneEDate.text = currentDate.ToString("dd", CultureInfo.CreateSpecificCulture("en-US"));
        SceneEDateLean.TranslationName = currentDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"));

        CheckDate();
    }

    void CheckDate()
    {
        switch (earthPivotRotation)
        {
            case 3:
                if (firstTask && (12 < currentDate.Hour && currentDate.Hour < 18))
                {
                    ContinueTestWindow1.SetActive(true);
                    //overlayCanvas.SetActive(false);
                    sceneECanvas.SetActive(false);
                    CancelInvoke("RotateAroundSun");
                    CancelInvoke("RotateAroundSelf");
                    CurrentContinueWindow = ContinueTestWindow1;
                    firstTask = false;
                    secondTask = true;
                }
                break;
            case earthPosition2:
                if (secondTask && (12 < currentDate.Hour && currentDate.Hour < 18))
                {
                    secondTask = false;
                    thirdTask = true;
                    ContinueTestWindow2.SetActive(true);
                    //overlayCanvas.SetActive(false);
                    sceneECanvas.SetActive(false);
                    CancelInvoke("RotateAroundSun");
                    CancelInvoke("RotateAroundSelf");
                    CurrentContinueWindow = ContinueTestWindow2;
                }
                break;
            case earthPosition3:
                if (thirdTask && (22 < currentDate.Hour || currentDate.Hour < 06))
                {
                    thirdTask = false;
                    forthTask = true;
                    ContinueTestWindow3.SetActive(true);
                    sceneECanvas.SetActive(false);
                    //overlayCanvas.SetActive(false);
                    CancelInvoke("RotateAroundSun");
                    CancelInvoke("RotateAroundSelf");
                    CurrentContinueWindow = ContinueTestWindow3;
                }
                break;
            case earthPosition4:
                if (forthTask && (12 < currentDate.Hour && currentDate.Hour < 18))
                {
                    forthTask = false;
                    ContinueTestWindow4.SetActive(true);
                    sceneECanvas.SetActive(false);
                    //overlayCanvas.SetActive(false);
                    CancelInvoke("RotateAroundSun");
                    CancelInvoke("RotateAroundSelf");
                    CurrentContinueWindow = ContinueTestWindow4;
                }
                break;
        }
    }

    public void HideContinueWindow()
    {
        sceneECanvas.SetActive(true);
        //overlayCanvas.SetActive(true);
        CurrentContinueWindow.SetActive(false);
    }

    public void BackButton()
    {
        resetExperiment();
        sceneECanvas.SetActive(true);
        sceneE.SetActive(false);
        //overlayCanvas.SetActive(true);
        scenarionSelection.SetActive(true);
        CurrentContinueWindow.SetActive(false);
    }
}
