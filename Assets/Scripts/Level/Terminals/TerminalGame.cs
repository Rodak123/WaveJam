using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TerminalGame : MonoBehaviour, ITerminalGame
{
    protected bool done;
    private bool paused;
    
    protected void OnDone()
    {
        ITerminalAction[] actions = GetComponents<ITerminalAction>();
        for (int i = 0; i < actions.Length; i++)
        {
            ITerminalAction action = actions[i];
            action.Execute();
        }
        done = true;
        paused = false;
    }

    public void Pause()
    {
        paused = true;
    }

    public void UnPause()
    {
        paused = false;
    }
    
    public bool IsDone()
    {
        return done;
    }

    public bool IsPaused()
    {
        return paused;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    protected void Restart()
    {
        done = false;
        paused = false;
    }

    public abstract void OnClose();
    public abstract void OnOpen();
    public abstract void OnStart();

    public abstract void ReSetup();
}
