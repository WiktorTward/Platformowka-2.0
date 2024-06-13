using UnityEngine;

public class Collectible_nachos : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with object tagged: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player"))
        {
            Game_manager_nachos.Instance.AddPointNachos();
            Destroy(gameObject);
        }

        ContactPoint contact = collision.contacts[0];
        Debug.Log("Collision at point: " + contact.point);
    }
}
