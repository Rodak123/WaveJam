using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyCode exitKey = KeyCode.Escape;

    [SerializeField] private bool useTargetFrameRate = false;
    [SerializeField] private int targetFrameRate = 60;
    
    private void Awake()
    {
        if(useTargetFrameRate) Application.targetFrameRate = targetFrameRate;
    }

    void Update()
    {
        if (Input.GetKeyDown(exitKey))
        {
            Application.Quit();
        }
    }

    public void ToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    
    public void ToGameScene()
    {
        Debug.Log("Hey");
        SceneManager.LoadScene("GameScene");
    }
    
    public void ToFinishScene()
    {
        SceneManager.LoadScene("FinishScene");
    }
}
