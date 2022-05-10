using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean;
using Lean.Localization;

public class Logic_Scenario2 : MonoBehaviour
{
    public GameObject SceneSelection;
    public GameObject SceneAMakeHypothesis;
    public GameObject SceneBMakeHypothesis;
    public GameObject SceneCMakeHypothesis;
    public GameObject SceneDMakeHypothesis;
    public GameObject YouAreRightWindow;
    public GameObject YouAreAlmostRightWindow;
    public GameObject YouAreWrongWindow;
    public GameObject SceneCHypothesisTestingWindows;
    public GameObject HypothesisIsTrue;
    public GameObject HypothesisIsNotTrue;

    // ссылки на объекты с анимациями
    public GameObject sceneA;
    public GameObject sceneB;
    public GameObject sceneC;
    public GameObject sceneD;
    public GameObject sceneE;
    public Animator animationSceneA;
    public Animator animationSceneB;

    // ссылки на тексты для ответов
    public TMP_Text YouAreRightWindowText;
    public TMP_Text YouAreAlmostRightWindowText;
    public TMP_Text YouAreWrongWindowText;
    public TMP_Text HypothesisIsTrueText;
    public TMP_Text HypothesisIsNotTrueText;

    public LeanLocalizedTextMeshProUGUI YouAreAlmostRightWindowLean;
    public LeanLocalizedTextMeshProUGUI YouAreRightWindowLean;
    public LeanLocalizedTextMeshProUGUI YouAreWrongWindowLean;
    public LeanLocalizedTextMeshProUGUI HypothesisIsTrueLean;
    public LeanLocalizedTextMeshProUGUI HypothesisIsNotTrueLean;

    // переменные для кнопки возврата
    private GameObject CurrentScene_HypothesisSelection; // выбор гипотезы текущей сцены
    private GameObject Pre_HypothesisSelectionAnimation; // анимация перед выбором гипотезы
    private GameObject CurrentAnswerWindow; // окно с ответом (результатом)
    private GameObject CurrentSceneAnimation; // обьект анимации
    private bool IsSceneAAnimation = false;

    void Start()
    {
        SceneSelection.SetActive(true);
        sceneA.SetActive(false);
        sceneB.SetActive(false);
        sceneC.SetActive(false);
        sceneD.SetActive(false);
        sceneE.SetActive(false);
    }

    private void StopPreExperimentAnimation ()
    {
        CurrentScene_HypothesisSelection.SetActive(true);
        Pre_HypothesisSelectionAnimation.SetActive(false);
    }

    public void ScenarioSelection(int id)
    {
        SceneSelection.SetActive(false);
        switch (id)
        {
            case 0:
                CurrentScene_HypothesisSelection = SceneAMakeHypothesis;
                Pre_HypothesisSelectionAnimation = sceneA;
                YouAreAlmostRightWindowLean.TranslationName = "The Sun’s diameter is about 100 times bigger than   the Earth’s diameter. This means that a million Earths put together make the size of the Sun.";
                YouAreRightWindowLean.TranslationName = "The truth is that    The Sun’s diameter is about 100 times bigger than the Earth’s diameter. his means that a million Earths put together make the size of the Sun.";
                YouAreWrongWindowLean.TranslationName = "Often things are not the way they look. In reality the Sun’s diameter is about 100 times bigger than the Earth’s diameter. This means that a million Earths put together make the size of the Sun.";
                Pre_HypothesisSelectionAnimation.SetActive(true);
                this.IsSceneAAnimation = false;
                Invoke("StopPreExperimentAnimation", 8.0f);
                break;
            case 1:
                CurrentScene_HypothesisSelection = SceneBMakeHypothesis;
                Pre_HypothesisSelectionAnimation = sceneB;
                YouAreRightWindowLean.TranslationName = "The Sun is about 150 million km away from the Earth. That is why such a huge object looks like a ball in the sky.";
                YouAreWrongWindowLean.TranslationName = "Often things are not the way they look. The truth is that the   Sun is much further away from the Earth than the clouds or even the moon. The Sun is about 150 million km away from the Earth. That is why such a huge object looks like a ball in the sky.";
                SceneBMakeHypothesis.SetActive(true);
                break;
            case 2:
                CurrentScene_HypothesisSelection = SceneCMakeHypothesis;
                Pre_HypothesisSelectionAnimation = sceneC;
                HypothesisIsTrueLean.TranslationName = "Your hypothesis is true. As you observed the Earth makes a complete revolution around the Sun in 365 days, that is in one year.";
                HypothesisIsNotTrueLean.TranslationName = "Your hypothesis is not true. You observed that it takes much longer than one day for the Earth to make a revolution around the Sun. In fact the Earth makes a complete revolution around the Sun in one year, that is in 365 days";
                SceneCMakeHypothesis.SetActive(true);
                break;
            case 3:
                CurrentScene_HypothesisSelection = SceneDMakeHypothesis;
                Pre_HypothesisSelectionAnimation = sceneD;
                SceneDMakeHypothesis.SetActive(true);
                HypothesisIsTrueLean.TranslationName = "Your hypothesis is true. As the chronometer showed, it takes 24   hours, that is one day and a night, for the Earth to complete a revolution   around itself.";
                HypothesisIsNotTrueLean.TranslationName = "Your hypothesis is not true. As the chronometer   showed, it takes 24 hours, that is one day and one night, for the Earth to   complete a revolution around itself.";
                break;
            case 4:
                CurrentScene_HypothesisSelection = sceneE;
                sceneE.SetActive(true);
                sceneE.GetComponent<SceneEAnimation>().StartButton();
                break;
        }
    }

    public void WindowsTransition(int id)
    {
        switch (id)
        {
            case 0: // SceneC - OKButton
                CurrentAnswerWindow.SetActive(true);
                CurrentSceneAnimation.SetActive(true);
                break;
            case 1: // Гипотеза C - показываем ответ (вызывается из скрипта SceneCAnimation и SceneDAnimation) 
                CurrentAnswerWindow.SetActive(true);
                break;
            case 2: // Гипотеза C - скрываем окно подтверждения (SceneCHypothesisTestingWindows)
                SceneCHypothesisTestingWindows.SetActive(false);
                CurrentSceneAnimation.SetActive(true);  //Показываем gameObject с 3d объектами
                break;
        }
    }

    private void OnEnable()
    {
        if (CurrentSceneAnimation == sceneA)
        {
            if (IsSceneAAnimation == true)
            {
                animationSceneA.Play("SceneA2");
                CancelInvoke("StopPreExperimentAnimation");
                Invoke("StopPreExperimentAnimation", 8.0f);
            }
            else
            {
                animationSceneA.Play("SceneA");
            }
        }
    }

    public void SceneALogic(int id)
    {
        this.IsSceneAAnimation = true;
        CurrentScene_HypothesisSelection.SetActive(false);
        CurrentSceneAnimation = sceneA;
        switch (id)
        {
            case 0:
                CurrentAnswerWindow = YouAreAlmostRightWindow;
                break;
            case 1:
                CurrentAnswerWindow = YouAreRightWindow;
                break;
            case 2:
                CurrentAnswerWindow = YouAreWrongWindow;
                break;
        }
        CurrentAnswerWindow.SetActive(true);
        CurrentSceneAnimation.SetActive(true);
        animationSceneA.Play("SceneA2");
    }

    public void SceneBLogic(int id)
    {
        CurrentScene_HypothesisSelection.SetActive(false);
        CurrentSceneAnimation = sceneB;
        switch (id)
        {
            case 0:
                CurrentAnswerWindow = YouAreRightWindow;
                break;
            case 1:
                CurrentAnswerWindow = YouAreWrongWindow;
                break;
        }
        CurrentAnswerWindow.SetActive(true);
        CurrentSceneAnimation.SetActive(true);
        animationSceneB.Play("SceneBStart");
    }

    public void SceneCLogic(int id)
    {
        CurrentScene_HypothesisSelection.SetActive(false);
        CurrentSceneAnimation = sceneC;
        sceneC.GetComponent<SceneCAnimation>().sceneCCanvas.SetActive(true);
        switch (id)
        {
            case 0:
                CurrentAnswerWindow = HypothesisIsTrue;
                break;
            case 1:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
        }
        SceneCHypothesisTestingWindows.SetActive(true);
    }

    public void SceneDLogic(int id)
    {
        CurrentScene_HypothesisSelection.SetActive(false);
        CurrentSceneAnimation = sceneD;
        sceneD.GetComponent<SceneDAnimation>().sceneDCanvas.SetActive(true);
        switch (id)
        {
            case 0:
                CurrentAnswerWindow = HypothesisIsTrue;
                break;
            case 1:
                CurrentAnswerWindow = HypothesisIsNotTrue;
                break;
        }
        CurrentSceneAnimation.SetActive(true);
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
                Pre_HypothesisSelectionAnimation.SetActive(false);
                break;
            case 2:
                SceneSelection.SetActive(true);
                //CurrentScene_HypothesisSelection.SetActive(true);
                CurrentSceneAnimation.SetActive(false);
                CurrentAnswerWindow.SetActive(false);
                break;
            default:
                break;
        }
    }
}
