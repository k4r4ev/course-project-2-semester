using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Localization;

public class Logic_Scenario1 : MonoBehaviour
{
    public GameObject Scenario1_SceneSelection;
    public GameObject MakeHypothesis1;
    public GameObject MakeHypothesis2;
    public GameObject AnotherHypothesis;
    public GameObject WarningWindow;
    public GameObject HypothesisTesting;
    public GameObject Experiment;

    public GameObject SceneA;
    public GameObject SceneB;

    public int CurrentHypothesisId;
    public int CorrectHypothesisId;

    public TMP_Text hypothesisTestingText;
    public TMP_Text warningWindowText;
    public TMP_Text anotherHypothesisText;

    public LeanLocalizedTextMeshProUGUI hypothesisTestingTextLean;
    public LeanLocalizedTextMeshProUGUI warningWindowTextLean;
    public LeanLocalizedTextMeshProUGUI anotherHypothesisTextLean;

    private string[] hypothesisTestingTextArray = { "“Fine! Now, you can make an experiment to test your hypothesis. Put the three big and   heavy objects on the sea to test your hypothesis”." ,
    "Fine! Now put the three small and light objects on the sea to test your hypothesis.", "Fine! Now put the two metal objects on the sea to test your hypothesis.",
    "Fine! Now put the two wooden objects on the sea to test your hypothesis", "Fine! Now put the two glass objects on the sea to test your hypothesis."};

    private string[] warningWindowTextArray = { "“This is a small and light object. Try all the big and heavy objects”" ,
    "This is a big and heavy object. Try all the small and light objects", "This is not made of metal. Try all the objects which are made of metal",
    "This is not made of wood. Try all the objects which are made of wood", "This is not made of glass. Try all the objects which are made of glass"};

    private string[] anotherHypothesisTextArray = { "Your   experiment showed that only some big and heavy objects float while others sink.   Your hypothesis was not proved. Try another hypothesis.”" ,
    "Your experiment that only some small and light objects float while others sink. Your hypothesis was not proved. Try another hypothesis.",
    "Your experiment that the objects which are made of metal do not float. Your hypothesis was not proved. Try another hypothesis.",
    "Your experiment that the objects which are made of wood float no matter whether they are big and heavy or small and light. Your hypothesis was proved. Excellent!",
    "Your experiment that the objects which are made of glass do not float. Your hypothesis was not proved. Try another hypothesis.", };

    private string[] hypothesisTestingTextSecondArray = { "Fine! Now make these objects hollow and put them on the sea to test your hypothesis", "Fine! Now make these objects curved and put them on the sea to test your hypothesis",
    "Fine! Now make these objects solid and put them on the sea to test your hypothesis"};

    private string[] warningWindowTextSecondArray = { "Your experiment showed that the hollow object made of metal (or glass depending on the selected object) floats. Try another object",
    "Your experiment showed that the curved object made of metal (or glass depending on the selected object) floats. Try another object",
    "Your experiment showed that the solid object made of metal (or glass depending on the selected object) floats. Try another object"};

    private string[] anotherHypothesisTextSecondArray = { "Your experiment showed that all hollow objects float. Your hypothesis was proved. Perhaps another hypothesis is also true. Try another hypothesis",
    "Your experiment showed that all the curved objects float. Your hypothesis was proved. Perhaps another hypothesis is also true. Try another hypothesis",
    "Your experiment showed that all the solid objects sink. Your hypothesis was not proved. Perhaps another hypothesis is true. Try another hypothesis"};

    private int ExperimentScene;
    [Space]
    [SerializeField] private GameObject CurrentHypothesisSelection;
    [SerializeField] private GameObject CurrentExperiment;

    public void ScenarioStart()
    {
        Scenario1_SceneSelection.SetActive(true);
        GetComponent<AudioSource>().Play();
    }

    public void ScenarioSelection(int id)
    {
        switch (id)
        {
            case 0:
                ExperimentScene = 0;
                Scenario1_SceneSelection.SetActive(false);
                Experiment.SetActive(true);
                SceneB.SetActive(false);
                SceneA.SetActive(true);
                CurrentHypothesisSelection = MakeHypothesis1;
                CurrentExperiment = SceneA;
                break;
            case 1:
                ExperimentScene = 1;
                Scenario1_SceneSelection.SetActive(false);
                SceneA.SetActive(false);
                SceneB.SetActive(true);
                CurrentHypothesisSelection = MakeHypothesis2;
                MakeHypothesis2.SetActive(true);
                CurrentExperiment = SceneB;
                break;
        }
    }

    public void StartFirstScene()
    {
        Experiment.SetActive(false);
        MakeHypothesis1.SetActive(true);
    }

    public void StartExperiment(int id)
    {
        MakeHypothesis1.SetActive(false);
        HypothesisTesting.SetActive(true);
        CurrentHypothesisId = id;

        FindObjectOfType<ObjLogic_SceneA>().SetSelectedHypothesisId(id);

        hypothesisTestingTextLean.TranslationName = hypothesisTestingTextArray[id];
        warningWindowTextLean.TranslationName = warningWindowTextArray[id];
        anotherHypothesisTextLean.TranslationName = anotherHypothesisTextArray[id];
    }

    public void StartSecondExperiment(int id)
    {
        MakeHypothesis2.SetActive(false);
        HypothesisTesting.SetActive(true);
        CurrentHypothesisId = id;
        FindObjectOfType<ObjLogic_SceneB>().ResetExperiment();

        FindObjectOfType<ObjLogic_SceneB>().SetSelectedHypothesisId(id);

        hypothesisTestingTextLean.TranslationName = hypothesisTestingTextSecondArray[id];
        warningWindowTextLean.TranslationName = warningWindowTextSecondArray[id];
        anotherHypothesisTextLean.TranslationName = anotherHypothesisTextSecondArray[id];
    }


    public void ExperimentResult()
    {
        Experiment.SetActive(false);
        AnotherHypothesis.SetActive(true);
    }

    public void ShowWarningWindow()
    {
        Experiment.SetActive(false);
        WarningWindow.SetActive(true);
    }

    public void BackButton(int id)
    {
        switch (id)
        {
            case 1: //Scenes
                Scenario1_SceneSelection.SetActive(false);
                break;
            case 2: //MakeHypothesis
                MakeHypothesis1.SetActive(false);
                Scenario1_SceneSelection.SetActive(true);
                break;
            case 3: //AnotherHypothesis
                AnotherHypothesis.SetActive(false);
                CurrentHypothesisSelection.SetActive(true);
                break;
            case 4: //WarningWindow
                WarningWindow.SetActive(false);
                MakeHypothesis1.SetActive(true);
                break;
            case 5: //HypothesisTesting
                HypothesisTesting.SetActive(false);
                MakeHypothesis1.SetActive(true);
                break;
            case 6: //Experiment
                if (SceneA.activeSelf && FindObjectOfType<ObjLogic_SceneA>().testing)
                {
                    Experiment.SetActive(false);
                    Scenario1_SceneSelection.SetActive(true);
                }
                else
                {
                    Experiment.SetActive(false);
                    CurrentHypothesisSelection.SetActive(true);
                }
                break;
        }
    }

    public void BackButtonAuto(int id)
    {
        switch (id)
        {
            case 0:
                Scenario1_SceneSelection.SetActive(true);
                HypothesisTesting.SetActive(false);
                CurrentHypothesisSelection.SetActive(false);
                FindObjectOfType<ObjLogic_SceneA>().ResetExperiment();
                FindObjectOfType<ObjLogic_SceneA>().ResetTestingName();
                break;
            case 1:
                Scenario1_SceneSelection.SetActive(true);
                CurrentHypothesisSelection.SetActive(false);
                CurrentExperiment.SetActive(false);
                FindObjectOfType<ObjLogic_SceneB>().ResetExperiment();
                break;
        }
    }

    public void WindowsTransition(int id)
    {
        switch (id)
        {
            case 1: //WarningWindow - OkButton
                WarningWindow.SetActive(false);
                Experiment.SetActive(true);
                break;
            case 2: //AnotherHypothesis - TryButton
                AnotherHypothesis.SetActive(false);
                if (ExperimentScene == 0)
                {
                    MakeHypothesis1.SetActive(true);
                    FindObjectOfType<ObjLogic_SceneA>().ResetExperiment();
                }
                if (ExperimentScene == 1)
                {
                    FindObjectOfType<ObjLogic_SceneB>().ResetExperiment();
                    MakeHypothesis2.SetActive(true);
                }
                break;
            case 3: //AnotherHypothesis - ExitButton
                AnotherHypothesis.SetActive(false);
                Scenario1_SceneSelection.SetActive(true);
                if (ExperimentScene == 0)
                {
                    FindObjectOfType<ObjLogic_SceneA>().ResetExperiment();
                    FindObjectOfType<ObjLogic_SceneA>().ResetTestingName();
                    SceneB.SetActive(false);
                }
                if (ExperimentScene == 1)
                {
                    FindObjectOfType<ObjLogic_SceneB>().ResetExperiment();
                    SceneB.SetActive(false);
                }
                break;
            case 4: //HypothesisTesting - OkButton
                HypothesisTesting.SetActive(false);
                Experiment.SetActive(true);
                break;
        }
    }
}
