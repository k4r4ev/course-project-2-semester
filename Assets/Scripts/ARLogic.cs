using System;
using System.Collections;
using System.Collections.Generic;
using easyar;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Vuforia;

public class ARLogic : MonoBehaviour
{

    public static bool Tracking;

    public ImageTargetController ImageTargetController1;
    public ImageTargetController ImageTargetController2;
    public ImageTargetController ImageTargetController3;

    string curMarkerName;

    public GameObject[] aMarkers;

	public GameObject scanMarkerWindow;

    private void Start()
    {
        ImageTargetController1.TargetFound += () =>
        {
            TrackingFound("ImageTargetScenario1");
        };
        ImageTargetController2.TargetFound += () =>
        {
            TrackingFound("ImageTargetScenario2");
        };
        ImageTargetController3.TargetFound += () =>
        {
            TrackingFound("ImageTargetScenario3");
        };        
        ImageTargetController1.TargetLost += TrackingLost;
        ImageTargetController2.TargetLost += TrackingLost;
        ImageTargetController3.TargetLost += TrackingLost;
    }

    int GetSceneIDByMarkerName(string markerName)
    {
        for (int i = 0; i < aMarkers.Length; i++)
        {
            //print(i+" "+aMarkers[i]);
            //if (aMarkers[i].GetComponent<ImageTarget>().Name == markerName)
            if (aMarkers[i].name == markerName)
            {
                return i;
            }
        }

        return -1;
    }

    public void NewMarkerFound(string markerName)
    {
        curMarkerName = markerName;

        int sceneID = GetSceneIDByMarkerName(markerName);
        if (sceneID >= 0) SendMessage("ScenarioSelected", sceneID);
        else Debug.LogError("Scene ID not found for markerName: " + markerName);
    }

    public void TrackingFound(string markerName)
    {
		scanMarkerWindow.SetActive(false);

		if (markerName != curMarkerName)
        {
            NewMarkerFound(markerName);
        }
        Tracking = true;
    }

    public void TrackingLost()
    {
        Tracking = false;
		scanMarkerWindow.SetActive(true);
	}
}
