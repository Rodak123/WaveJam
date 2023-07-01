using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalTimeAdder : MonoBehaviour, ITerminalAction
{
    [SerializeField] private Player player;
    [SerializeField] private float timeAdded = 2f;
    
    public void Execute()
    {
        player.AddTime(timeAdded);
    }
}
