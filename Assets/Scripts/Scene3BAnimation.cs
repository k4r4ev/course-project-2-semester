using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3BAnimation : MonoBehaviour
{
    public GameObject Scenario;
    public Transform spacestation;
    public Transform station;
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
            animationSceneA.Play("Scene3Afall");
        }
    }

    public void ResetExperiment()
    {
        CancelInvoke("SpacestationRotate");
        InvokeRepeating("SpacestationRotate", 0, 0.02f);
        spaceStationRotation = 0;
        state = true;
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


    private void SpacestationRotate()
    {
        spaceStationRotation -= step;
        spacestation.localEulerAngles = new Vector3(0, spaceStationRotation, 0);
        if (spaceStationRotation == -360)
        {
            spaceStationRotation = 0;
        }
    }

    public void TurnOffVelocity()
    {
        if (state)
        {
            state = false;
            Invoke("ResetAnimation", 2.9f);
            Invoke("ShowAnswer", 3);
            CancelInvoke("SpacestationRotate");
            animationSceneA.Play("Scene3Afall");
            //BackButton.SetActive(false);
            //ResetButton.SetActive(false);
            //GravButton.SetActive(false);
        }
        /*
        state = false;
        if (state)
        {
            CancelInvoke("SpacestationRotate");
            animationSceneA.Play("Scene3Afall");
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

    private void ResetAnimation()
    {
        animationSceneA.Play("Scene3A");
    }

    private void ShowAnswer()
    {
        ResetExperiment();
        //BackButton.SetActive(true);
        //ResetButton.SetActive(true);
        //GravButton.SetActive(true);
        Scenario.GetComponent<Logic_Scenario3>().ShowAnswer();
    }
}
