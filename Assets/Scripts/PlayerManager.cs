using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool gameStart;
    public GameObject startText;

    public static int numberOfCoins;
    public Text scoreText;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        gameStart = false;
        numberOfCoins = 0;
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
          //  Debug.Log("Obstacool");
        }

        scoreText.text = "Score: " + numberOfCoins;

        if (SwipeManager.tap)
        {
            gameStart = true;
            Destroy(startText);
        }
    }
}
