using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using SkyInnovations;
using Lean.Localization;
using TMPro;

public class Scenario1Object : MonoBehaviour
{
    public GameObject Scenario1Logic;
    public GameObject NamingWindow;
    public GameObject Arrow;
    public LeanLocalizedTextMeshProUGUI NamingWindowText;
    public string NamingWindowTextP;

    public int id;
    public string objectName;
    public bool drownable = false;
    public bool TestName = true;
    public bool TestNameLogic = true;

    private bool valid = false;

    public bool Valid
    {
        get => valid;
        set
        {
            Debug.Log("Setting drag to: " + value);
            GetComponent<TouchControlWithLift>().draggable = value;
            valid = value;
        }
    }

    public void SetText(string str)
    {
        NamingWindowTextP = str;
    }

    public void ShowArrow()
    {
        Arrow.SetActive(true);
    }

    public void HideArrow()
    {
        Arrow.SetActive(false);
    }

    private void OnMouseDown()
    {
        Arrow.SetActive(false);
        if (TestName)
        {
            TestNameLogic = false;
            NamingWindowText.TranslationName = NamingWindowTextP;
            NamingWindow.SetActive(true);
        }
        else
        {
            if (Utilities.IsPointerOverUIObject() || EventSystem.current.IsPointerOverGameObject()) return;

            if (!this.valid)
            {
                Scenario1Logic.GetComponent<Logic_Scenario1>().ShowWarningWindow();
            }
            else
            {
                //Scenario1Logic.GetComponent<ObjLogic_Scenario1>().thrownObjectsCounter();
            }
        }
    }
}
