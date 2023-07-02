using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITerminalGame
{
    public bool IsDone();
    public bool IsPaused();

    public void UnPause();
    public GameObject GetGameObject();

    public void OnClose();
    public void OnOpen();
    
    public void ReSetup();
    public void OnStart();
}
