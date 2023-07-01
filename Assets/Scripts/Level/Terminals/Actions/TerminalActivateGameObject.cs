using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalActivateGameObject : MonoBehaviour, ITerminalAction
{
    [SerializeField] private GameObject activatingGameObject;
    [SerializeField] private bool targetState = true;
    
    public void Execute()
    {
        activatingGameObject.SetActive(targetState);
    }
}
