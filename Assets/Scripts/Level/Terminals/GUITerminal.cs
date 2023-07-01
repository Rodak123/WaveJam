using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITerminal : MonoBehaviour
{
    
    [SerializeField] private GameObject terminalGameObject;
    private ITerminalGame terminal;

    private Terminal openedBy;
    
    void Start()
    {
        terminal = terminalGameObject.GetComponent<ITerminalGame>();
        terminal.GetGameObject().SetActive(false);
    }

    void Update()
    {
        if (terminal.IsDone())
        {
            Close();
        }
        else if (terminal.IsPaused())
        {
            Close();
            openedBy.Paused();
        }
    }

    public void Open(Terminal openedBy)
    {
        if (terminal.IsPaused())
        {
            terminal.UnPause();
        }
        else
        {
            this.openedBy = openedBy;
        }
        terminal.GetGameObject().SetActive(true);
    }

    public void Close()
    {
        openedBy.OnTerminalClosed();
        terminal.GetGameObject().SetActive(false);
    }

    public void Restart()
    {
        if (terminal.GetGameObject().activeSelf)
        {
            Close();
        }
        terminal.ReSetup();
    }
}
