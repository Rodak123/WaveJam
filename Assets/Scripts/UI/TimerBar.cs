using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private Image image;

    [SerializeField] private Color[] stateColors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue
    };

    [SerializeField] private float stateColorPulseSpeed = 0.5f;
    private float stateColorTimer = 0;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (uiManager.player.GameStarted())
        {
            image.color = stateColors[2];
        }
        else
        {
            stateColorTimer += stateColorPulseSpeed * Time.deltaTime;
            float blend = (Mathf.Sin(stateColorTimer) + 1.0f) / 2.0f;
            image.color = Color.Lerp(stateColors[0], stateColors[1], blend);
        }
        
        Vector3 newScale = transform.localScale;
        newScale.x = uiManager.player.GetTimeLeft();
        transform.localScale = newScale;
    }
}
