using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coœ");
        if (other.CompareTag("Player"))
        {
            CheckpointManager.Instance.SetCheckpoint(transform.position);
            Debug.Log("Checkpoint reached at: " + transform.position);
        }
    }

}

