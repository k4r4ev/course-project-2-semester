using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Script : MonoBehaviour
{
    public GameObject safetyAlert;
    int safetyAlertShownOnce = 0;

    void Start()
    {
        CheckSafetyAlert();
    }

    void CheckSafetyAlert()
    {
        if (!PlayerPrefs.HasKey("safetyAlertShownOnce"))
        {
            safetyAlert.SetActive(true);
            PlayerPrefs.SetInt("safetyAlertShownOnce", 1);
        }
    }
}
