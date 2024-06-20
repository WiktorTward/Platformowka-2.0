using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToNewScene : MonoBehaviour
{
    // Nazwa sceny, do której chcemy teleportowaæ gracza
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy collider wejœcia nale¿y do gracza
        if (other.CompareTag("Player"))
        {
            // Za³aduj now¹ scenê
            SceneManager.LoadScene(sceneName);
        }
    }
}

