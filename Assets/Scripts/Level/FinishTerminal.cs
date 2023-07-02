using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTerminal : MonoBehaviour, IInteractive
{
    [SerializeField] private bool oneUse = true;
    private bool used = false;

    private Animator finishAnimator;

    [SerializeField] private Player player;
    [SerializeField] private GameObject canvasTimer;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        finishAnimator = GetComponent<Animator>();
    }

    protected void Action()
    {
        canvasTimer.SetActive(false);
        player.Finished();
        finishAnimator.Play("Explosion");
    }

    public void Exploded()
    {
        gameManager.ToFinishScene();
    }

    public void Interact()
    {
        if(!CanInteract()) return;
        used = true;
        Action();
    }

    public bool CanInteract()
    {
        if (!oneUse) return true;
        return used == false;
    }

    public void Restart()
    {
        used = false;
    }
    
    public bool CanUnlockMovement()
    {
        return false;
    }
}
