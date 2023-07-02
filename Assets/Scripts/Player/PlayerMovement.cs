using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1000f;
    private float movementSpeedScale = 1f;

    public bool moved = false;
    public bool readyToMove = false;

    private bool lockedMovement = false;

    private Rigidbody2D rb;
    
    [SerializeField] private AudioSource footstepsAudio;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(!readyToMove || lockedMovement) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        if (!moved && movement.magnitude > 0)
        {
            moved = true;
        }
        footstepsAudio.volume = (rb.velocity.magnitude > 0.1 ? 1 : 0);
        rb.velocity = movement * (movementSpeed * movementSpeedScale * Time.deltaTime);

    }

    public void Restart()
    {
        Input.ResetInputAxes();
        moved = false;
        rb.velocity = Vector2.zero;
        readyToMove = false;
        movementSpeedScale = 1f;
    }

    public void SetMovementSpeedScale(float scale)
    {
        movementSpeedScale = scale;
    }

    public void Lock()
    {
        lockedMovement = true;
    }

    public void Unlock()
    {
        lockedMovement = false;
    }
}
