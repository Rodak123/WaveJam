using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WordTerminal : TerminalGame
{
    [SerializeField] private string[] randomWords = new string[]
    {
        "Flask",
        "Tube",
        "Beaker",
        "Pipette",
        "Lab",
        "Bunsen",
        "Probe",
        "Micro",
        "Scale",
        "Reagent"
    };
    
    [SerializeField] private String chosenWord = "NONE";

    void Start()
    {
        PickRandomWord();
    }

    public void WordInput(String inputtedWord)
    {
        // TODO
    }

    private void PickRandomWord()
    {
        Random random = new Random();
        chosenWord = randomWords[random.Next(randomWords.Length)];
    }

    public override void ReSetup()
    {
        PickRandomWord();
        Restart();
    }
}
