using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Lean.Localization;
using UnityEngine.UI;

public class Scene3CAnimation : MonoBehaviour
{
    public float[] Orbits;
    public float[] SpeedSteps;
    public Transform spacestationPivot;
    public Transform spacestation;

    public GameObject PromptCanvas;
    public LeanLocalizedTextMeshProUGUI ResultMessage;
    public TMP_Text PromptMessage;

    public LeanLocalizedTextMeshProUGUI PromptMessageLean;

    public Button[] OrbitButtons;

    public Slider slid;

    public GameObject SceneC;
    public GameObject SceneCCanvas;
    public GameObject mainMenu;
    public GameObject Scenario;

    private float fallOrbit = 0;
    private float outOrbit = 1;

    private int orbit;
    private int speed = 0;
    [SerializeField] private float step = 0;
    [SerializeField] private float invokeTimeRight = 8f;
    [SerializeField] private float invokeTimeWrong = 4f;
    private float[] steps =  { 0, 0.5f, 1f, 1.5f };
    private float orbitPosition;
    private float spaceStationRotation = 0;

    private String[] Numbers = { "Put the satellite in an orbit around the Earth. Choose the right velocity for the first orbit",
        "Choose the right velocity for the second orbit", "Choose the right velocity for the third orbit" };
    private int necessesaryOrbit = 0;

    void Start()
    {
        SceneCCanvas.SetActive(false);
        PromptCanvas.SetActive(true);
        TurnOffButtons();
        OrbitButtons[0].interactable = true;
        //PromptMessageLean.TranslationName = Numbers[necessesaryOrbit];
    }

    public void ContinueExperiment()
    {
        SceneCCanvas.SetActive(true);
        PromptCanvas.SetActive(false);
    }

    public void CompleteExperiment()
    {
        necessesaryOrbit = 0;
        ResetExperiment();
        SceneC.SetActive(false);
        Scenario.GetComponent<Logic_Scenario3>().SceneCMakeHypothesisWindow();
        TurnOffButtons();
        OrbitButtons[0].interactable = true;
        PromptMessageLean.TranslationName = Numbers[0];
        ResultMessage.TranslationName = null;
        SceneCCanvas.SetActive(true);
        SceneC.SetActive(false);
        PromptCanvas.SetActive(true);
    }

    public void BackToMenu()
    {
        ResetExperiment();
        necessesaryOrbit = 0;
        SceneCCanvas.SetActive(true);
        SceneC.SetActive(false);
        mainMenu.SetActive(true);
        PromptCanvas.SetActive(true);
        TurnOffButtons();
        OrbitButtons[0].interactable = true;
        PromptMessageLean.TranslationName = Numbers[0];
        ResultMessage.TranslationName = null;
    }

    private void TurnOffButtons() { 
        foreach (Button btn in OrbitButtons)
        {
            btn.interactable = false;
        }
    }


    public void ResetExperiment()
    {
        slid.value = 0;
        spaceStationRotation = 0;
        CancelInvoke();
        //step = 0.5f;
        //speed = 0;
        spacestation.DOKill();
        spacestation.DOLocalMoveX(Orbits[necessesaryOrbit], 1);
        spacestationPivot.localEulerAngles = new Vector3(0, spaceStationRotation, 0);
        CancelInvoke(nameof(SpacestationRotate));
    }


    public void SetSpeedStep(float speed)
    {
        this.speed = Convert.ToInt32(speed);
        step = SpeedSteps[this.speed];
        Debug.Log(speed);
    }

    private void SpacestationRotate()
    {
        spaceStationRotation -= step;
        spacestationPivot.localEulerAngles = new Vector3(0, spaceStationRotation, 0);
        if (spaceStationRotation == -360)
        {
            spaceStationRotation = 0;
        }
    }

    public void ChangeOrbit(int orbit)
    {
        this.orbit = orbit;
        orbitPosition = Orbits[orbit];
        //Debug.Log(orbitPosition);
        spacestation.DOLocalMoveX(orbitPosition, 1.5f);
        CancelInvoke(nameof(SpacestationRotate));
        InvokeRepeating(nameof(SpacestationRotate), 0, 0.02f);
        Rotation(orbit);
    }

    public void RightOrbit()
    {
        if (necessesaryOrbit < 2)
        {
            ResetExperiment();
            necessesaryOrbit++;
            TurnOffButtons();
            OrbitButtons[necessesaryOrbit].interactable = true;
            ////////
            SceneCCanvas.SetActive(false);
            PromptCanvas.SetActive(true);
            ResultMessage.TranslationName = "Right Orbit";
            PromptMessageLean.TranslationName = Numbers[necessesaryOrbit];
            ////////
            spacestation.DOLocalMoveX(Orbits[necessesaryOrbit], 1.5f);
        }
        else
        {
            necessesaryOrbit = 0;
            CompleteExperiment();
        }
        Debug.Log("RightOrbit");
    }

    public void WrongOrbit()
    {
        ResetExperiment();
        spacestation.DOLocalMoveX(Orbits[necessesaryOrbit], 1.5f);
        ///////
        SceneCCanvas.SetActive(false);
        PromptCanvas.SetActive(true);
        ResultMessage.TranslationName = "Wrong Orbit";
        PromptMessageLean.TranslationName = Numbers[necessesaryOrbit];
        //////
        Debug.Log("WrongOrbit");
    }

    public void Rotation(int orbit)
    {
        switch (orbit)
        {
            case 0:
                // Запускаем спутник
                if (this.speed == 0 || this.speed == 1 || this.speed == 2)
                {
                    spacestation.DOLocalMoveX(fallOrbit, 10f);
                }
                else if (this.speed == 3)
                {
                    spacestation.DOLocalMoveX(orbitPosition, 1.5f);
                }
                // Проверяем нужную орбиту
                if (necessesaryOrbit == 0 && (this.speed == 3))
                {
                    Invoke(nameof(RightOrbit), invokeTimeRight);
                } 
                else
                {
                    Invoke(nameof(WrongOrbit), invokeTimeWrong);
                }
                break;
            case 1:
                // Запускаем спутник
                if (this.speed == 0 || this.speed == 1)
                {
                    spacestation.DOLocalMoveX(fallOrbit, 10f);
                }
                else if (this.speed == 2)
                {
                    spacestation.DOLocalMoveX(orbitPosition, 1.5f);
                }
                else if (this.speed == 3)
                {
                    spacestation.DOLocalMoveX(outOrbit, 10f);
                }
                // Проверяем нужную орбиту
                if (necessesaryOrbit == 1 && this.speed == 2)
                {
                    Invoke(nameof(RightOrbit), invokeTimeRight);
                }
                else
                {
                    Invoke(nameof(WrongOrbit), invokeTimeWrong);
                }
                break;
            case 2:
                // Запускаем спутник
                if (this.speed == 0)
                {
                    spacestation.DOLocalMoveX(fallOrbit, 10f);
                }
                else if (this.speed == 1)
                {
                    spacestation.DOLocalMoveX(orbitPosition, 1.5f);
                }
                else if (this.speed == 2 || this.speed == 3)
                {
                    spacestation.DOLocalMoveX(outOrbit, 20f);
                }
                // Проверяем нужную орбиту
                if (necessesaryOrbit == 2 && this.speed == 1)
                {
                    Invoke(nameof(RightOrbit), invokeTimeRight);
                }
                else
                {
                    Invoke(nameof(WrongOrbit), invokeTimeWrong);
                }
                break;
        }
    }
}
