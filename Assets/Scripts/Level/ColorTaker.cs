using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTaker : MonoBehaviour
{

    private Color color = Color.grey; 
    
    [SerializeField]
    private ColorPalette.PaletteColor myColor = ColorPalette.PaletteColor.Walls;
    
    void Start()
    {
        color = ColorPalette.GetColor(myColor);
        
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = color;
        }

        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.color = color;
        }
    }
}
