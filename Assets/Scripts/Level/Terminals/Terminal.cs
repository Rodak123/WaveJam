using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractive
{
    [SerializeField] private bool oneUse = true;
    private bool used = false;

    [SerializeField] private GUITerminal guiTerminal;

    private bool freeToGo = false;

    [SerializeField] private AudioSource openAudio;
    
    protected void Action()
    {
        guiTerminal.Open(this);
    }

    public void Interact()
    {
        if(!CanInteract()) return;
        used = true;
        freeToGo = false;
        openAudio.Play();
        Action();
    }

    public bool CanInteract()
    {
        if (!oneUse) return true;
        return used == false;
    }

    public void Restart()
    {
        if(guiTerminal != null)
            guiTerminal.Restart();
        used = false;
    }

    public void Paused()
    {
        used = false;
    }

    public void OnTerminalClosed()
    {
        freeToGo = true;
    }
    
    public bool CanUnlockMovement()
    {
        return freeToGo;
    }
}
