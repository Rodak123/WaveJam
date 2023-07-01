using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class MathTerminal : TerminalGame
{
    [SerializeField] private TextMeshProUGUI firstNumberText;
    [SerializeField] private TextMeshProUGUI operationText; 
    [SerializeField] private TextMeshProUGUI secondNumberText;

    [SerializeField] private TextMeshProUGUI[] results;

    private string[] operations = { "+", "-" };
    
    [SerializeField] private int minNumber = 0;
    [SerializeField] private int maxNumber = 10;

    private int resultNumber;
    private int correctResultIndex = 0;

    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        Random random = new Random();
        
        int firstNumber = random.Next(minNumber, maxNumber);
        int secondNumber = random.Next(minNumber, maxNumber);
        int operationIndex = random.Next(0, operations.Length);

        string operation = operations[operationIndex];
        if (firstNumber < secondNumber && operation == "-")
        {
            (firstNumber, secondNumber) = (secondNumber, firstNumber);
        }

        resultNumber = GetResult(firstNumber, operation, secondNumber);
        correctResultIndex = random.Next(0, results.Length);

        firstNumberText.text = firstNumber.ToString();
        operationText.text = operation;
        secondNumberText.text = secondNumber.ToString();

        correctResultIndex = random.Next(0, results.Length);
        for (int i = 0; i < results.Length; i++)
        {
            TextMeshProUGUI resultText = results[i];
            if (correctResultIndex == i)
            {
                resultText.text = resultNumber.ToString();
                continue;
            }
            
            int value;
            do
            {
                firstNumber = random.Next(minNumber, maxNumber);
                secondNumber = random.Next(minNumber, maxNumber);
                if (firstNumber < secondNumber && operation == "-")
                {
                    (firstNumber, secondNumber) = (secondNumber, firstNumber);
                }
                value = GetResult(firstNumber, operation, secondNumber);;
            } while (value == resultNumber);
            
            resultText.text = value.ToString();
        }
    }

    private int GetResult(int a, String operation, int b)
    {
        switch (operation)
        {
            case "+":
                return a + b;
            case "-":
                return a - b;
        }
        return 0;
    }

    public void SubmitAnswer(int index)
    {
        if(correctResultIndex != index) return;
        OnDone();
    }
}
