using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTerminal : TerminalGame
{
    public void OpenLock()
    {
        OnDone();
    }
    
    public override void ReSetup()
    {
        Restart();
    }
}
