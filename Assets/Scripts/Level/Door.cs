using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : MonoBehaviour, IInteractive
{
    private enum OpeningDirection
    {
        Up, Down, Left, Right
    }

    [SerializeField]
    private OpeningDirection direction = OpeningDirection.Left;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float fullyOpenedAt = 0.05f;
    
    private bool opening = false;
    
    [SerializeField]
    private bool startsUnlocked = true;
    private bool unlocked;

    private Vector3 startPosition;
    private Vector3 startScale;

    void Start()
    {
        startPosition = transform.position;
        startScale = transform.localScale;
        unlocked = startsUnlocked;
    }

    void Update()
    {
        if (opening)
        {
            float blend = Mathf.Pow(0.5f, Time.deltaTime * speed);

            Vector3 currentScale = transform.localScale;
            Vector3 currentPosition = transform.position;
            float scale = 0;
            switch (direction)
            {
                case OpeningDirection.Up:
                    float currentTop = currentPosition.y + currentScale.y * 0.5f;
                    float endTop = currentPosition.y - currentScale.y * 0.5f;
                    float desiredTop = Mathf.Lerp(endTop, currentTop, blend);

                    float scaleY = currentScale.y - Mathf.Abs(desiredTop - currentTop);
                    currentPosition.y += (currentScale.y - scaleY) * 0.5f;
                    currentScale.y = scaleY;
                    scale = scaleY;
                    break;

                case OpeningDirection.Down:
                    float currentBottom = currentPosition.y - currentScale.y * 0.5f;
                    float endBottom = currentPosition.y + currentScale.y * 0.5f;
                    float desiredBottom = Mathf.Lerp(endBottom, currentBottom, blend);

                    scaleY = currentScale.y - Mathf.Abs(desiredBottom - currentBottom);
                    currentPosition.y -= (currentScale.y - scaleY) * 0.5f;
                    currentScale.y = scaleY;
                    scale = scaleY;
                    break;

                case OpeningDirection.Left:
                    float currentLeft = currentPosition.x - currentScale.x * 0.5f;
                    float endLeft = currentPosition.x + currentScale.x * 0.5f;
                    float desiredLeft = Mathf.Lerp(endLeft, currentLeft, blend);

                    float scaleX = currentScale.x - Mathf.Abs(desiredLeft - currentLeft);
                    currentPosition.x += (currentScale.x - scaleX) * 0.5f;
                    currentScale.x = scaleX;
                    scale = scaleX;
                    break;

                case OpeningDirection.Right:
                    float currentRight = currentPosition.x + currentScale.x * 0.5f;
                    float endRight = currentPosition.x - currentScale.x * 0.5f;
                    float desiredRight = Mathf.Lerp(endRight, currentRight, blend);

                    scaleX = currentScale.x - Mathf.Abs(desiredRight - currentRight);
                    currentPosition.x -= (currentScale.x - scaleX) * 0.5f;
                    currentScale.x = scaleX;
                    scale = scaleX;
                    break;
            }
            transform.localScale = currentScale;
            transform.position = currentPosition;

            if (scale <= fullyOpenedAt)
            {
                OnFullyOpened();
            }
        }
    }

    private void Open()
    {
        opening = true;
    }

    private void OnFullyOpened()
    {
        gameObject.SetActive(false);
    }
    
    public void Interact()
    {
        if (!CanInteract()) return;

        Open();
    }

    public bool CanInteract()
    {
        return !opening && unlocked;
    }

    public void Unlock()
    {
        unlocked = true;
    }

    public void Restart()
    {
        opening = false;
        transform.position = startPosition;
        transform.localScale = startScale;
        unlocked = startsUnlocked;
        gameObject.SetActive(true);
    }
    
}
