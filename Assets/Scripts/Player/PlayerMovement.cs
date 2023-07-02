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

    [SerializeField] private Vector3 lastPos;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        if(!readyToMove || lockedMovement) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        if (movement.magnitude > 0)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle+90f);
            if (!moved)
            {
                moved = true;
            }
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
