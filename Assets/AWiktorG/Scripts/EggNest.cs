using UnityEngine;

public class EggNest : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E; // Klawisz do zebrania jajek
    public GameObject eggs; // Referencja do obiektu jajek
    private bool inTrigger = false; // Czy gracz jest w triggerze?

    private void Update()
    {
        // Sprawdzamy, czy gracz wciœnie klawisz E i jajka nie zosta³y jeszcze zebrane
        if (inTrigger && Input.GetKeyDown(pickupKey) && eggs.activeSelf)
        {
            CollectEggs();
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

    private void CollectEggs()
    {
        // Schowaj jajka (zak³adaj¹c, ¿e jajka to aktywny obiekt)
        eggs.SetActive(false);

        // Zapisz w pamiêci gry, ¿e jajka zosta³y zebrane
        GameManager.Instance.SaveEggsCollected(true); // GameManager to przyk³adowa klasa zarz¹dzaj¹ca gr¹

        // Dodajemy debug log
        Debug.Log("Jajka zosta³y zebrane!");

        // Mo¿esz dodaæ tutaj dodatkowe dzia³ania po zebraniu jajek
    }
}
