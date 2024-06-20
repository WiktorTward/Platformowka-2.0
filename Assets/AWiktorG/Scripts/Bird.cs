using UnityEngine;

public class Bird : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Klawisz do interakcji
    private bool inTrigger = false; // Czy gracz jest w triggerze?

    private void Update()
    {
        // Sprawdzamy, czy gracz wciœnie klawisz E i jest w triggerze
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
        // Sprawdzamy, czy jajka zosta³y ju¿ zebrane
        bool eggsCollected = GameManager.Instance.AreEggsCollected();

        // Jeœli jajka zosta³y zebrane, mo¿emy je oddaæ ptakowi
        if (eggsCollected)
        {
            // Zapisujemy, ¿e jajka zosta³y oddane
            GameManager.Instance.SaveEggsGiven(true);

            // Mo¿esz dodaæ tutaj dodatkowe dzia³ania, np. odtworzenie animacji, dŸwiêku, etc.

            // Przyk³adowo, mo¿emy zniszczyæ obiekt jajek po ich oddaniu
            Destroy(GameObject.FindWithTag("Eggs"));

            Debug.Log("Jajka zosta³y oddane ptakowi!");
        }
        else
        {
            Debug.Log("Nie masz jeszcze jajek do oddania!");
        }
    }
}
