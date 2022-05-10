using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAAnimation : MonoBehaviour
{
    public GameObject Scenario;
    public Transform spacestation;
    public Animator animationSceneA;

    public GameObject ResetButton;
    public GameObject BackButton;
    public GameObject GravButton;

    private float step = 0.5f;
    private float spaceStationRotation = 0;
    private bool state = true;

    void Start()
    {
        InvokeRepeating("SpacestationRotate", 0, 0.02f);
    }

    private void OnEnable()
    {
        if (!state)
        {
            animationSceneA.Play("Scene3Aoff");
        }
    }

    public void ResetExperiment()
    {
        spaceStationRotation = 0;
        CancelInvoke("SpacestationRotate");
        InvokeRepeating("SpacestationRotate", 0, 0.02f);
        state = true;
    }

    private void SpacestationRotate()
    {
        spaceStationRotation -= step;
        spacestation.localEulerAngles = new Vector3(0, spaceStationRotation, 0);
        if (spaceStationRotation == -360)
        {
            spaceStationRotation = 0;
        }
    }

    IEnumerator BackReset()
    {
        CancelInvoke("ShowAnswer");
        ResetAnimation();
        ResetExperiment(); 
        yield return new WaitForSeconds(0.01f);
        FindObjectOfType<Logic_Scenario3>().BackButtonAuto(1);
    }

    public void BackButtonHelper()
    {
        StartCoroutine(BackReset());
    }

    public void TurnOffGravity()
    {
        if (state)
        {
            state = false;
            Invoke("ResetAnimation", 3.9f);
            Invoke("ShowAnswer", 4);
            CancelInvoke("SpacestationRotate");
            animationSceneA.Play("Scene3Aoff");
            //BackButton.SetActive(false);
            //GravButton.SetActive(false);
            //ResetButton.SetActive(false);
        }
        /*
        if (state)
        {
            CancelInvoke("SpacestationRotate");
            animationSceneA.Play("Scene3Aoff");
            state = false;
        }
        else
        {
            InvokeRepeating("SpacestationRotate", 0, 0.02f);
            animationSceneA.Play("Scene3A");
            state = true;
        }
        */
    }

    private void ResetAnimation ()
    {
        animationSceneA.Play("Scene3A");
    }

    private void ShowAnswer()
    {
        ResetExperiment();
        //BackButton.SetActive(true);
        //GravButton.SetActive(true);
        //ResetButton.SetActive(true);
        Scenario.GetComponent<Logic_Scenario3>().ShowAnswer();
    }
}
