using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeriminalSlowDownTime : MonoBehaviour, ITerminalAction
{
    [SerializeField] private Player player;
    [SerializeField] private float newTimeScale = 0.75f;

    public void Execute()
    {
        player.SetTimeScale(newTimeScale);
    }
}
