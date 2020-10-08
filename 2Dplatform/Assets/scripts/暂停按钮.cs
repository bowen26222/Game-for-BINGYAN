﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 暂停按钮 : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject 暂停;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void pause()
    {
        暂停.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }
    public void resume()
    {
        暂停.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }
    public void newstart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
}
