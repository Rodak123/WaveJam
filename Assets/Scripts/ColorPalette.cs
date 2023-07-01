using System;
using UnityEngine;

public static class ColorPalette
{
    public enum PaletteColor
    {
        Walls = 0,
        Door = 1,
        
        Pink = 2,
        Red = 3,
        Orange = 4,
        Cyan = 5,
        Green = 6,
        
        Terminal = 7,
    }
    
    private static readonly Color[] Colors = new []
    {
        new Color(0.76f, 0.76f, 0.76f), // walls
        new Color(21 / 255f, 123 / 255f, 255 / 255f), // doors
        
        new Color(252 / 255f, 115 / 255f, 255 / 255f), // pink
        new Color(255 / 255f, 122 / 255f, 115 / 255f), // red
        new Color(255 / 255f, 173 / 255f, 64 / 255f), // orange
        new Color(115 / 255f, 244 / 255f, 255 / 255f), // cyan
        new Color(143 / 255f, 255 / 255f, 77 / 255f), // green
        
        new Color(127 / 255f, 129 / 255f, 144 / 255f), // terminal
    };

    public static Color GetColor(PaletteColor color)
    {
        int index = (int)color;
        if (index < 0 || index >= Colors.Length)
        {
            return Color.gray;
        }
        return Colors[index];
    }
}