using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM2;

public class SprintController : MonoBehaviour
{
    public Character character; // Reference to the "Character" script
    public float sprintMultiplier = 1.5f; // Multiplier for sprint speed

    private float originalMaxWalkSpeed; // Original walking speed value

    private void Start()
    {
        originalMaxWalkSpeed = character.maxWalkSpeed; // Store the original walking speed
    }

    private void Update()
    {
        // Check if the Left Shift key is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // If Left Shift is pressed, increase the character's walking speed to achieve sprinting
            character.maxWalkSpeed = originalMaxWalkSpeed * sprintMultiplier;
        }
        else
        {
            // If Left Shift is not pressed, reset the character's walking speed to its original value
            character.maxWalkSpeed = originalMaxWalkSpeed;
        }
    }
}


