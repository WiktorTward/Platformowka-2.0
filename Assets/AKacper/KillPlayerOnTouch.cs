using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawd�, czy obiekt, kt�ry dotkn�� platformy, ma tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
           

            // Lub, je�li chcesz bezpo�rednio zniszczy� obiekt gracza:
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy obiekt, kt�ry dotkn�� platformy, ma tag "Player"
        if (other.CompareTag("Player"))
        {


            // Lub, je�li chcesz bezpo�rednio zniszczy� obiekt gracza:
            Destroy(other.gameObject);
        }
    }
}
