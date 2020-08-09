﻿//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
   
}
