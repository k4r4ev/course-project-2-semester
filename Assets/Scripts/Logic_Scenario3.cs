using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Localization;

public class Logic_Scenario3 : MonoBehaviour
{
    public GameObject SceneSelection;
    public GameObject SceneAMakeHypothesis;
    public GameObject SceneBMakeHypothesis;
    public GameObject SceneCMakeHypothesis;

    public TMP_Text HypothesisIsTrueText;
    public TMP_Text HypothesisIsNotTrueText;

    public GameObject HypothesisIsTrue;
    public GameObject HypothesisIsNotTrue;

    public LeanLocalizedTextMeshProUGUI HypothesisIsTrueLean;
    public LeanLocalizedTextMeshProUGUI HypothesisIsNotTrueLean;

    public GameObject sceneA;
    public GameObject sceneB;
    public GameObject sceneC;

    // переменные для кнопки возврата
    private GameObject CurrentScene_HypothesisSelection; // выбор гипотезы текущей сцены
    private GameObject Pre_HypothesisSelectionAnimation; // анимация перед выбором гипотезы
    private GameObject CurrentAnswerWindow; // окно с ответом (результатом)
    private GameObject CurrentSceneAnimation; // обьект анимации

    void Start()
    {
        SceneSelection.SetActive(true);
        sceneA.SetActive(false);
        sceneB.SetActive(false);
        sceneC.SetActive(false);
    }

    void Update() { }

    public void ScenarioSelection(int id)
    {
        SceneSelection.SetActive(false);
        switch (id)
        {
            case 0:
                CurrentScene_HypothesisSelection = SceneAMakeHypothesis;
                HypothesisIsTrueLean.TranslationName = "Excellent! Your hypothesis is true. If we could   stop the force of gravity, the satellite would continue moving on a straight   line, because there would be nothing to change its motion.";
                HypothesisIsNotTrueLean.TranslationName = "Your hypothesis is not true. If we could stop the   force of gravity, the satellite would continue moving on a straight line. This   would happen because there would be nothing to change its motion.";
                //HypothesisIsTrueText.text = "Excellent! Your hypothesis is true. If we could stop the force of gravity, the satellite would continue moving on a straight line, because there would be nothing to change its motion.";
                //HypothesisIsNotTrueText.text = "Your hypothesis is not true. If we could stop the force of gravity, the satellite would continue moving on a straight line. This would happen because there would be nothing to change its motion.";
                break;
            case 1:
                CurrentScene_HypothesisSelection = SceneBMakeHypothesis;
                HypothesisIsTrueLean.TranslationName = "Excellent! Your hypothesis proved true. If the   satellite stops, then the force of gravity would attract (pull) it towards the   center of the earth.";
                HypothesisIsNotTrueLean.TranslationName = "Your hypothesis is not true. The force of gravity   still attracts the satellite even if the satellite stops. That is why the   satellite falls towards the center of the earth.";
                //HypothesisIsTrueText.text = "Excellent! Your hypothesis proved true. If the satellite stops, then the force of gravity would attract (pull) it towards the center of the earth.";
                //HypothesisIsNotTrueText.text = "Your hypothesis is not true. The force of gravity still attracts the satellite even if the satellite stops. That is why the satellite falls towards the center of the earth.";
                break;
            case 2:
                CurrentScene_HypothesisSelection = SceneCMakeHypothesis;
                HypothesisIsTrueLean.TranslationName = "Excellent! The closer to the earth, the greater is the force of gravity with which the earth attracts the satellite. Therefore, the satellite must move faster in order not to fall on the earth.";
                HypothesisIsNotTrueLean.TranslationName = "Not really! Try again and you find out that the closer to the earth the satellite is, the greater its velocity should be. And here is the reason: You know that the closer to the earth, the greater is the force of gravity with which the earth attracts the satellite. Therefore, the satellite must move faster in order not to fall on the earth.";
                //HypothesisIsTrueText.text = "Excellent! The closer to the earth, the greater is the force of gravity with which the earth attracts the satellite. Therefore, the satellite must move faster in order not to fall on the earth.";
                //HypothesisIsNotTrueText.text = "Not really! Try again and you find out that the closer to the earth the satellite is, the greater its velocity should be. And here is the reason: You know that the closer to the earth, the greater is the force of gravity with which the earth attracts the satellite. Therefore, the satellite must move faster in order not to fall on the earth.";
                CurrentSceneAnimation = sceneC;
                CurrentSceneAnimation.SetActive(true);
                return;
        }
        CurrentScene_HypothesisSelection.SetActive(true);
    }

    public void SceneALogic(int id)
    {
        switch (id)
        {
            case 0:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
            case 1:
                CurrentAnswerWindow = HypothesisIsTrue;
                break;
            case 2:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
            case 3:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
        }
        CurrentScene_HypothesisSelection.SetActive(false);
        CurrentSceneAnimation = sceneA;
        CurrentSceneAnimation.SetActive(true);
    }

    public void SceneBLogic(int id)
    {
        switch (id)
        {
            case 0:
                CurrentAnswerWindow = HypothesisIsTrue;
                break;
            case 1:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
            case 2:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
            case 3:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
            case 4:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
        }
        CurrentScene_HypothesisSelection.SetActive(false);
        CurrentSceneAnimation = sceneB;
        CurrentSceneAnimation.SetActive(true);
    }

    public void SceneCMakeHypothesisWindow()
    {
        CurrentScene_HypothesisSelection.SetActive(true);
    }

    public void SceneCLogic(int id)
    {
        switch (id)
        {
            case 0:
                CurrentAnswerWindow = HypothesisIsTrue;
                break;
            case 1:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
            case 2:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
        }
        CurrentScene_HypothesisSelection.SetActive(false); 
        ShowAnswer();
    }

    public void ShowAnswer()
    {
        CurrentSceneAnimation.SetActive(false);
        CurrentAnswerWindow.SetActive(true);
    }

    public void BackButtonAuto(int id)
    {
        switch (id)
        {
            case 0:
                SceneSelection.SetActive(true);
                CurrentScene_HypothesisSelection.SetActive(false);
                break;
            case 1:
                SceneSelection.SetActive(true);
                //CurrentScene_HypothesisSelection.SetActive(true);
                CurrentSceneAnimation.SetActive(false);
                //Pre_HypothesisSelectionAnimation.SetActive(false);
                break;
            case 2:
                SceneSelection.SetActive(true);
                //CurrentScene_HypothesisSelection.SetActive(true);
                //CurrentSceneAnimation.SetActive(false);
                CurrentAnswerWindow.SetActive(false);
                break;
            default:
                break;
        }
    }
}
