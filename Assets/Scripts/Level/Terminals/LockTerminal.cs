using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class LockTerminal : TerminalGame
{
    public String pin = "000";
    public String nextPin = "000";

    [SerializeField] private TMP_Text nextPinText;

    [SerializeField] private TMP_InputField pinInput;

    private void Awake()
    {
        GeneratePin();
        GeneratePin();
    }

    public void PinInput(String inputtedPin)
    {
        if (inputtedPin.ToLower().Equals(pin))
        {
            OnDone();
        }
        else if (inputtedPin.Length >= 3)
        {
            pinInput.text = string.Empty;
        }
    }

    private void GeneratePin()
    {
        pin = nextPin;
        
        Random random = new Random();
        int pinNumber = random.Next(1000);
        nextPin = pinNumber.ToString("D3");
        nextPinText.text = string.Join(" ", nextPin.ToCharArray());
    }
    
    public override void ReSetup()
    {
        GeneratePin();
        Restart();
    }
    
    public override void OnClose()
    {
    }
    
    public override void OnOpen()
    {
        pinInput.text = string.Empty;
    }
}
