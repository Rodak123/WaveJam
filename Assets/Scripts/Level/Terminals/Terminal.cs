using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractive
{
    [SerializeField] private bool oneUse = true;
    private bool used = false;

    [SerializeField] private GUITerminal guiTerminal;
    
    protected void Action()
    {
        guiTerminal.Open(this);
    }

    public void Interact()
    {
        if(!CanInteract()) return;
        used = true;
        Action();
    }

    public bool CanInteract()
    {
        if (!oneUse) return true;
        return used == false;
    }

    public void Restart()
    {
        used = false;
    }

    public void Paused()
    {
        used = false;
    }
}
