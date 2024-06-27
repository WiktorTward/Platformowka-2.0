using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 3f;
    public float knockbackForce = 5f;

    private Transform currentTarget;

    void Start()
    {
        // Set the initial target to pointA
        currentTarget = pointA;
    }

    void Update()
    {
        // Move towards the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

        // Check if we've reached the current target
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            // If current target is pointA, switch to pointB; otherwise switch to pointA
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate knockback direction
            Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;

            // Apply knockback force to the player
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
