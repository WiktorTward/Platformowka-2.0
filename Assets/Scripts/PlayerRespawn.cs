using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    void Start()
    {
        checkpointManager = CheckpointManager.Instance;
    }

    void Update()
    {
        // Przyk�adowe resetowanie pozycji gracza (np. po naci�ni�ciu klawisza R)
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = checkpointManager.GetCheckpoint();
        Debug.Log("Player respawned at: " + checkpointManager.GetCheckpoint());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("death"))
        {
            Respawn();
        }
    }
}