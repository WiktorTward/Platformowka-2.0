using UnityEngine;

public class EggNest : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E; // Klawisz do zebrania jajek
    public GameObject eggs; // Referencja do obiektu jajek
    private bool inTrigger = false; // Czy gracz jest w triggerze?

    private void Update()
    {
        // Sprawdzamy, czy gracz wci�nie klawisz E i jajka nie zosta�y jeszcze zebrane
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
        // Schowaj jajka (zak�adaj�c, �e jajka to aktywny obiekt)
        eggs.SetActive(false);

        // Zapisz w pami�ci gry, �e jajka zosta�y zebrane
        GameManager.Instance.SaveEggsCollected(true); // GameManager to przyk�adowa klasa zarz�dzaj�ca gr�

        // Dodajemy debug log
        Debug.Log("Jajka zosta�y zebrane!");

        // Mo�esz doda� tutaj dodatkowe dzia�ania po zebraniu jajek
    }
}
