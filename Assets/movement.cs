using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
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

        // Normalize movement to prevent faster diagonal movement
        dir = dir.normalized;
    }

    void FixedUpdate()
    {
        // Apply movement to the player
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
    }
}
