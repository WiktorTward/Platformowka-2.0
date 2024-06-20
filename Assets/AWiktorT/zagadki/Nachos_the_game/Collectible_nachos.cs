using UnityEngine;

public class Collectible_nachos : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Game_manager_nachos.Instance.AddPointNachos();
            Destroy(gameObject);
        }


    }
}
