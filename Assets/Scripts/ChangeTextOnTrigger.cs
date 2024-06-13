using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextOnTrigger : MonoBehaviour
{
    public TextMesh textMesh; // Referencja do komponentu Text Mesh Pro

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt, który wszed³ w trigger, ma tag "Player"
        if (other.CompareTag("Player"))
        {
            // Zmieniamy tekst na nowy
            textMesh.text = "Press E to pick up";
        }
    }
}
