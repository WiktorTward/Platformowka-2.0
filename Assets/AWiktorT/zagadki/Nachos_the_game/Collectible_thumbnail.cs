using UnityEngine;

public class Collectible_thumbnail : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Game_manager_nachos.Instance.AddPointThumbnail();
            Destroy(gameObject);
        }
    }
}
