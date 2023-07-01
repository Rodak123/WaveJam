using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalDoorOpener : MonoBehaviour, ITerminalAction
{
    [SerializeField] private Door door;
    
    public void Execute()
    {
        door.Unlock();
        door.Interact();
    }
}
