using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoNaked : MonoBehaviour
{
    public GameObject character; // Referencja do obiektu postaci
    public GameObject[] elementsToDisable; // Tablica element�w do wy��czenia

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sprawd�, czy obiekt w triggerze to posta�
        {
            foreach (GameObject element in elementsToDisable)
            {
                element.SetActive(false); // Wy��cz ka�dy element z tablicy
            }
        }
    }
}

