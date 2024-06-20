using UnityEngine;
using UnityEngine.UIElements;

public class SquidGameJumper : MonoBehaviour
{
    public float fallDelay = 0f;
    public float fallSpeed = 10f;

    private Rigidbody rb;

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("touch");
            rb.isKinematic = false;
            rb.velocity = new Vector3(0, -fallSpeed, 0);
        }
            
    }
}