using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode useKey = KeyCode.E;
    [SerializeField] private KeyCode readyUpKey = KeyCode.Space;

    private IInteractive interactingWith;
    
    [SerializeField] private float startTimeLeft = 40f;
    [SerializeField] private float maxTimeLeft;
    [SerializeField] private float timeLeft;
    [SerializeField] private bool timerRunning = false;

    [SerializeField] private float timerSpeedScale = 1f;

    [SerializeField] private LayerMask interactiveLayers;

    private PlayerMovement playerMovement;

    private Vector3 spawnPosition;

    [SerializeField] private Level Level;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        spawnPosition = transform.position;
        
        timeLeft = startTimeLeft;
        maxTimeLeft = startTimeLeft;
    }

    void Update()
    {
        if (timerRunning)
        {
            UpdateTimer();
        }
        else
        {
            timerRunning = playerMovement.moved;
        }

        if (Input.GetKeyDown(useKey) && CanUse())
        {
            if(Input.GetKeyDown(useKey)){
                interactingWith.Interact();
                playerMovement.Lock();
            }
        }

        if (interactingWith != null && interactingWith.CanUnlockMovement())
        {
            playerMovement.Unlock();
        }

        if (Input.GetKeyDown(readyUpKey))
        {
            playerMovement.readyToMove = true;
        }
    }

    private void UpdateTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime * timerSpeedScale;
        }
        else if (timeLeft <= 0)
        {
            OnTimeOut();
        }
    }

    private void ResetTimer()
    {
        timeLeft = startTimeLeft;
        maxTimeLeft = startTimeLeft;
        timerRunning = false;
    }
    
    private void OnTimeOut()
    {
        Level.Restart();
        RespawnBack();
    }

    private void RespawnBack()
    {
        transform.position = spawnPosition;
        ResetTimer();
        playerMovement.Restart();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetupInteractingWith(other);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        SetupInteractingWith(other);
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (IsInteractive(other.gameObject))
        {
            interactingWith = null;
            playerMovement.Unlock();
        }
    }

    private void SetupInteractingWith(Collision2D other)
    {
        if (IsInteractive(other.gameObject) && interactingWith == null)
        {
            interactingWith = other.gameObject.GetComponent<IInteractive>();
        }
    }

    private bool IsInteractive(GameObject gameObject)
    {
        return interactiveLayers == (interactiveLayers | (1 << gameObject.layer));
    }

    public float GetTimeLeft()
    {
        return Mathf.Max(0, Mathf.Min(timeLeft / maxTimeLeft, 1));
    }

    public bool CanUse()
    {
        if(interactingWith == null) return false;
        return interactingWith.CanInteract();
    }

    public bool GameStarted()
    {
        return playerMovement.readyToMove;
    }

    public void AddTime(float time)
    {
        timeLeft = Mathf.Max(timeLeft + time, 0);
        if (timeLeft > maxTimeLeft)
        {
            maxTimeLeft = timeLeft;
        }
    }

    public void SetSpeedScale(float scale)
    {
        playerMovement.SetMovementSpeedScale(scale);
    }

    public void SetTimeScale(float scale)
    {
        timerSpeedScale = scale;
    }
}
