using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM2;

public class SprintController : MonoBehaviour
{
    public Character character; // Referencja do skryptu "Character"
    public float sprintMultiplier = 1.5f; // Mno�nik pr�dko�ci sprintu

    private float originalMaxWalkSpeed; // Oryginalna warto�� pr�dko�ci chodzenia

    private void Start()
    {
        originalMaxWalkSpeed = character.maxWalkSpeed; // Zapami�taj oryginaln� pr�dko�� chodzenia
    }

    private void Update()
    {
        // Sprawd�, czy przycisk LShift jest wci�ni�ty
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Je�li tak, ustaw pr�dko�� chodzenia na mno�nik pr�dko�ci sprintu
            character.maxWalkSpeed = originalMaxWalkSpeed * sprintMultiplier;
        }
        else
        {
            // Je�li nie, przywr�� oryginaln� pr�dko�� chodzenia
            character.maxWalkSpeed = originalMaxWalkSpeed;
        }
    }
}

