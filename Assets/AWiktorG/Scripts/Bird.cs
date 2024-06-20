using UnityEngine;

public class Bird : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Klawisz do interakcji
    private bool inTrigger = false; // Czy gracz jest w triggerze?

    private void Update()
    {
        // Sprawdzamy, czy gracz wci�nie klawisz E i jest w triggerze
        if (inTrigger && Input.GetKeyDown(interactKey))
        {
            GiveEggsToBird();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

    private void GiveEggsToBird()
    {
        // Sprawdzamy, czy jajka zosta�y ju� zebrane
        bool eggsCollected = GameManager.Instance.AreEggsCollected();

        // Je�li jajka zosta�y zebrane, mo�emy je odda� ptakowi
        if (eggsCollected)
        {
            // Zapisujemy, �e jajka zosta�y oddane
            GameManager.Instance.SaveEggsGiven(true);

            // Mo�esz doda� tutaj dodatkowe dzia�ania, np. odtworzenie animacji, d�wi�ku, etc.

            // Przyk�adowo, mo�emy zniszczy� obiekt jajek po ich oddaniu
            Destroy(GameObject.FindWithTag("Eggs"));

            Debug.Log("Jajka zosta�y oddane ptakowi!");
        }
        else
        {
            Debug.Log("Nie masz jeszcze jajek do oddania!");
        }
    }
}
