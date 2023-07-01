using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject[] interactiveElements;
    private List<IInteractive> interactives;

    void Start()
    {
        interactives = new List<IInteractive>();
        for (int i = 0; i < interactiveElements.Length; i++)
        {
            IInteractive element = interactiveElements[i].GetComponent<IInteractive>();
            if(element == null) return;
            interactives.Add(element);
        }
    }

    public void Restart()
    {
        for (int i = 0; i < interactives.Count; i++)
        {
            IInteractive interactive = interactives[i];
            interactive.Restart();
        }
    }
    
}
