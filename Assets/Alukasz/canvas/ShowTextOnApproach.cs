using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnApproach : MonoBehaviour
{
    public string tagToCheck = "Sparrow"; // Tag, kt�ry sprawdzamy
    public string eggTag = "Eggs"; // Tag dla obiekt�w "Eggs"
    public float detectionRadius = 5.0f; // Promie� detekcji
    public Canvas displayCanvas; // Canvas, kt�ry b�dzie wy�wietlany
    public Text PrzyniesJaja; // Tekst, kt�ry b�dzie wy�wietlany na canvasie
    public string message = "Przynies mi Jaja!"; // Wiadomo�� do wy�wietlenia
    public string collectedMessage = "Dzi�kuj� za przyniesienie jaj!"; // Wiadomo�� po zebraniu jaj

    private bool hasCollectedEggs = false; // Czy gracz zebra� jajka

    private void Start()
    {
        if (displayCanvas != null)
        {
            displayCanvas.enabled = false; // Ukryj Canvas na pocz�tku
        }
    }

    private void Update()
    {
        if (displayCanvas != null && PrzyniesJaja != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
            bool foundTag = false;
            bool foundEggs = false;

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag(tagToCheck))
                {
                    foundTag = true;
                }

                if (hitCollider.CompareTag(eggTag))
                {
                    foundEggs = true;
                }
            }

            if (foundEggs)
            {
                hasCollectedEggs = true;
                Destroy(GameObject.FindWithTag(eggTag)); // Usu� obiekt "Eggs"
            }

            if (hasCollectedEggs)
            {
                PrzyniesJaja.text = collectedMessage;
                displayCanvas.enabled = true; // Poka� Canvas z drug� wiadomo�ci�
            }
            else if (foundTag)
            {
                PrzyniesJaja.text = message;
                displayCanvas.enabled = true; // Poka� Canvas z pierwsz� wiadomo�ci�
            }
            else
            {
                displayCanvas.enabled = false; // Ukryj Canvas, gdy gracz nie jest w pobli�u odpowiednich obiekt�w
            }
        }
    }

    // Aby zobaczy� promie� detekcji w edytorze
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
