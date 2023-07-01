using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectHider : MonoBehaviour
{

    [SerializeField] private bool hidden;
    [SerializeField] private GameObject toHide;

    void Start()
    {
        UpdateToHide();
    }

    public void UpdateToHide()
    {
        toHide.SetActive(!hidden);
    }

    public void SetActive(bool active)
    {
        if(hidden == !active) return;
        hidden = !active;
        UpdateToHide();
    }
    
    public void Show()
    {
        SetActive(true);
    }

    public void Hide()
    {
        SetActive(false);
    }

}
