using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TimeTerminal : TerminalGame
{
    
    [SerializeField] private Transform clockHand;
    private ClockHand clockHandScript;

    [SerializeField] private int timeHour;
    [SerializeField] private int targetHourTime;

    private void Start()
    {
        clockHandScript = clockHand.gameObject.GetComponent<ClockHand>();
    }

    private void UpdateTargetTime(bool force)
    {
        int newTargetHourTime = DateTime.Now.Hour % 12;
        
        if(force == false && targetHourTime == newTargetHourTime) return;
        
        targetHourTime = newTargetHourTime;
        Random random = new Random();
        timeHour = random.Next(12);
        if (timeHour == targetHourTime)
        {
            timeHour = (timeHour+(random.Next(2)==0?1:-1) + 12) % 12;
        }
        UpdateClockHand();
    }

    private void UpdateClockHand()
    {
        float angle = 90 + timeHour * -30;
        clockHand.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Update()
    {
        UpdateTargetTime(false);
        timeHour = clockHandScript.GetHour();
        if(!clockHandScript.IsGrabbed()){
            if (timeHour == targetHourTime)
            {
                OnDone();
            }
        }
    }

    public override void ReSetup()
    {
        Restart();
    }

    public override void OnClose()
    {
    }
    
    public override void OnOpen()
    {
        UpdateTargetTime(true);
    }
}
