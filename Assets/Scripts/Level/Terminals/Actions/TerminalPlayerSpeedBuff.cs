using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalPlayerSpeedBuff : MonoBehaviour, ITerminalAction
{
    [SerializeField] private Player player;
    [SerializeField] private float speedScale = 2f;
    
    public void Execute()
    {
        player.SetSpeedScale(speedScale);
    }
}
