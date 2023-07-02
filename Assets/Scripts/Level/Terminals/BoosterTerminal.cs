using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterTerminal : TerminalGame
{
    [SerializeField] private Image[] boosterLights;

    [SerializeField] private Color lightOff = ColorPalette.GetColor(ColorPalette.PaletteColor.Pink);
    [SerializeField] private Color lightOn = ColorPalette.GetColor(ColorPalette.PaletteColor.Pink);

    [SerializeField] private float boostGain = 0.1f;
    [SerializeField] private float boostLoss = 0.05f;
    [SerializeField] private float boost = 0;

    private int boosters = 0;

    [SerializeField] private AudioSource chargeUpAudio;

    private bool reachedBoost;

    public void Boost()
    {
        boost += boostGain;
    }

    public void Update()
    {
        if (boost is > 0 and < 1)
        {
            boost -= boostLoss * Time.deltaTime;
            if (boost < 0)
            {
                boost = 0;
            }
        }
        else if (boost >= 1 && !reachedBoost)
        {
            OnDone();
            reachedBoost = true;
            boost = 1f;
        }
        UpdateBoosterLights();
    }
    
    private void UpdateBoosterLights()
    {
        int boostersOn = (int)Math.Floor(boost * boosterLights.Length);
        for (int i = 0; i < boosterLights.Length; i++)
        {
            Image boosterLight = boosterLights[i];
            boosterLight.color = i<boostersOn?lightOn:lightOff;
        }
        if (boostersOn > boosters)
        {
            chargeUpAudio.Play();
        }
        boosters = boostersOn;
    }

    public override void OnStart()
    {
    }

    public override void ReSetup()
    {
        boost = 0;
        boosters = 0;
        reachedBoost = false;
        Restart();
    }

    public override void OnClose()
    {
        boost = 0;
        reachedBoost = false;
    }
    
    public override void OnOpen()
    {
        boost = 0;
        reachedBoost = false;
        UpdateBoosterLights();
    }
}
