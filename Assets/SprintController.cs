using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM2;


public class SprintController : MonoBehaviour
{
    public Character character; // Referencja do skryptu "Character"
    private float originalmaxWalkSpeed; // Oryginalna warto�� pr�dko�ci chodzenia

    private void Start()
    {
        originalmaxWalkSpeed = character.maxWalkSpeed; // Zapami�taj oryginaln� pr�dko�� chodzenia
    }

    private void Update()
    {
        // Sprawd�, czy przycisk LShift jest wci�ni�ty
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Je�li tak, ustaw pr�dko�� chodzenia na 1.5x oryginalnej warto�ci
            character.maxWalkSpeed = originalmaxWalkSpeed * 1.5f;
        }
        else
        {
            // Je�li nie, przywr�� oryginaln� pr�dko�� chodzenia
            character.maxWalkSpeed = originalmaxWalkSpeed;
        }
    }
}
