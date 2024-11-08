using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    bool isRunning = false;
    float stamina = 10;
    private Rigidbody2D rb;
    private Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for horizontal and vertical movement
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)) //Om vi håller inne shift och stamina är mer än 0
        {
            isRunning = true;
            //minska stamina
        }
        else
        {
            isRunning = false;
        }
        // Normalize movement to prevent faster diagonal movement
        dir = dir.normalized;
    }

    void FixedUpdate()
    {
        // Apply movement to the player
        rb.MovePosition(rb.position + dir * moveSpeed * (isRunning ? 2 : 1) * Time.fixedDeltaTime);
    }
}