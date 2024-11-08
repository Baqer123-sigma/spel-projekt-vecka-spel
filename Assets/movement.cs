using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    bool isRunning = false;
    float stamina = 10;
    private Rigidbody2D rb;
    private Vector2 dir;
    float staminaDrainRate = 3;
    public Slider StaminaCounter; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StaminaCounter.value = stamina;
        // Get input for horizontal and vertical movement
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0) //Om vi håller inne shift och stamina är mer än 0
        {
            isRunning = true;
            stamina -= staminaDrainRate * Time.deltaTime;
        } else
        {
            isRunning = false;
            stamina = Mathf.Clamp(stamina, 0, 10);
            stamina += staminaDrainRate * Time.deltaTime;
            
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
