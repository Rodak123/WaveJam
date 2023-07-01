using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTerminal : TerminalGame
{
    public void Boost()
    {
        OnDone();
    }
    
    public override void ReSetup()
    {
        Restart();
    }
}
