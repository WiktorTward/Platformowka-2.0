using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnApproach : MonoBehaviour
{
    public string tagToCheck = "Sparrow"; // Tag, który sprawdzamy
    public string eggTag = "Eggs"; // Tag dla obiektów "Eggs"
    public float detectionRadius = 5.0f; // Promieñ detekcji
    public Canvas displayCanvas; // Canvas, który bêdzie wyœwietlany
    public Text PrzyniesJaja; // Tekst, który bêdzie wyœwietlany na canvasie
    public string message = "Przynies mi Jaja!"; // Wiadomoœæ do wyœwietlenia
    public string collectedMessage = "Dziêkujê za przyniesienie jaj!"; // Wiadomoœæ po zebraniu jaj

    private bool hasCollectedEggs = false; // Czy gracz zebra³ jajka

    private void Start()
    {
        if (displayCanvas != null)
        {
            displayCanvas.enabled = false; // Ukryj Canvas na pocz¹tku
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
                Destroy(GameObject.FindWithTag(eggTag)); // Usuñ obiekt "Eggs"
            }

            if (hasCollectedEggs)
            {
                PrzyniesJaja.text = collectedMessage;
                displayCanvas.enabled = true; // Poka¿ Canvas z drug¹ wiadomoœci¹
            }
            else if (foundTag)
            {
                PrzyniesJaja.text = message;
                displayCanvas.enabled = true; // Poka¿ Canvas z pierwsz¹ wiadomoœci¹
            }
            else
            {
                displayCanvas.enabled = false; // Ukryj Canvas, gdy gracz nie jest w pobli¿u odpowiednich obiektów
            }
        }
    }

    // Aby zobaczyæ promieñ detekcji w edytorze
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
