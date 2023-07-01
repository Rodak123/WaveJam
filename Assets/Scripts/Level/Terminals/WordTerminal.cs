using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class WordTerminal : TerminalGame
{
    [SerializeField] private string[] randomWords = new string[]
    {
        // "Flask",
        // "Tube",
        // "Beaker",
        // "Lab",
        // "Bunsen",
        // "Probe",
        // "Micro",
        // "Scale",
        "AAA",
        "BBB",
        "CCC",
        "DDD",
        "EEE",
        "FFF",
        "GGG",
        "HHH",
        "III",
        "JJJ",
        "KKK",
        "LLL",
        "MMM",
        "NNN",
        "OOO",
        "PPP",
        "QQQ",
        "RRR",
        "SSS",
        "TTT",
        "UUU",
        "VVV",
        "WWW",
        "XXX",
        "YYY",
        "ZZZ",
    };
    
    [SerializeField] private String chosenWord = "NONE";

    [SerializeField] private TextMeshProUGUI chosenWordText;
    [SerializeField] private TMP_InputField wordInput;
    
    void Start()
    {
        PickRandomWord();
    }

    public void WordInput(String inputtedWord)
    {
        if (inputtedWord.ToLower().Equals(chosenWord))
        {
            OnDone();
        }
    }

    private void PickRandomWord()
    {
        Random random = new Random();
        chosenWord = randomWords[random.Next(randomWords.Length)].ToLower();
        chosenWordText.text = chosenWord;
        wordInput.text = string.Empty;
    }

    public override void ReSetup()
    {
        PickRandomWord();
        Restart();
    }

    public override void OnClose()
    {
        wordInput.text = string.Empty;
    }

    public override void OnOpen()
    {
        wordInput.ActivateInputField();
    }
}
