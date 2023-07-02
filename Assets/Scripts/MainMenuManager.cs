using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credits;

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
    
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
