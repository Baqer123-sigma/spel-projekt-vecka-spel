using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Regular speed of the player
    [HideInInspector] public float originalMoveSpeed; // Store the original speed as public for access by PlayerSprint
    private Rigidbody2D rb;
    private Vector2 movement;

    // Keybinds for movement
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found. Please attach a Rigidbody2D to this GameObject.");
        }

        originalMoveSpeed = moveSpeed; // Initialize the original move speed
    }

    void Update()
    {
        // Reset movement each frame
        movement = Vector2.zero;

        // Check for key presses for movement
        if (Input.GetKey(upKey))
        {
            movement.y = 1;
        }
        else if (Input.GetKey(downKey))
        {
            movement.y = -1;
        }

        if (Input.GetKey(leftKey))
        {
            movement.x = -1;
        }
        else if (Input.GetKey(rightKey))
        {
            movement.x = 1;
        }

        // Normalize movement to prevent faster diagonal movement
        if (movement.magnitude > 0.1f)
        {
            movement = movement.normalized;
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the player
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
