using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITerminal : MonoBehaviour
{
    
    [SerializeField] private GameObject terminalGameObject;
    private ITerminalGame terminal;

    private Terminal openedBy;

    [SerializeField] private AudioSource GUIButtonAudio;

    private bool terminalClosed = true;
    
    void Start()
    {
        terminal = terminalGameObject.GetComponent<ITerminalGame>();
        terminal.GetGameObject().SetActive(false);
    }

    public void PlayButtonAudio()
    {
        GUIButtonAudio.Play();
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
        if(!terminalClosed) return;
        terminalClosed = false;
        terminal.OnOpen();
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
        if(terminalClosed) return;
        terminalClosed = true;
        PlayButtonAudio();
        openedBy.OnTerminalClosed();
        terminal.OnClose();
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
