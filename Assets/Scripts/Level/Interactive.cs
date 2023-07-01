using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    public void Interact();
    public bool CanInteract();
    public void Restart();
    public bool CanUnlockMovement();
}
