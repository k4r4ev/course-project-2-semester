﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Logic : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync("Scenarios");
    }
}
