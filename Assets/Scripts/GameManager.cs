using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyCode exitKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(exitKey))
        {
            Application.Quit();
        }
    }
}
