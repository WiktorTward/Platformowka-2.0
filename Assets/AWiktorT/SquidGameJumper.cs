using ECM2;
using UnityEngine;

public class SquidGameJumper : MonoBehaviour
{
    public float fallDelay = 0f;
    public float fallSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Character character = other.GetComponent<Character>();
        if (character)
        {
            Debug.Log("touch");
            rb.isKinematic = false;
            rb.velocity = new Vector3(0, -fallSpeed, 0);
        }
            
    }
}
