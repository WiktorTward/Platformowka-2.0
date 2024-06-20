using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToNewScene : MonoBehaviour
{
    // Nazwa sceny, do kt�rej chcemy teleportowa� gracza
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy collider wej�cia nale�y do gracza
        if (other.CompareTag("Player"))
        {
            // Za�aduj now� scen�
            SceneManager.LoadScene(sceneName);
        }
    }
}

