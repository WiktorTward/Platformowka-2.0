using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ, czy obiekt, który dotkn¹³ platformy, ma tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
           

            // Lub, jeœli chcesz bezpoœrednio zniszczyæ obiekt gracza:
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy obiekt, który dotkn¹³ platformy, ma tag "Player"
        if (other.CompareTag("Player"))
        {


            // Lub, jeœli chcesz bezpoœrednio zniszczyæ obiekt gracza:
            Destroy(other.gameObject);
        }
    }
}
