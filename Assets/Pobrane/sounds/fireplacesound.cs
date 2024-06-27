using UnityEngine;

public class Campfire : MonoBehaviour
{
    public AudioClip campfireSound;
    public float soundRadius = 10f;

    private AudioSource audioSource;
    private Transform player;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Nie mo¿na znaleŸæ obiektu gracza.");
        }

        PlayCampfireSound();
    }

    private void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.position) > soundRadius)
            {
                StopCampfireSound();
            }
            else
            {
                PlayCampfireSound();
            }
        }
    }

    private void PlayCampfireSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = campfireSound;
            audioSource.Play();
        }
    }

    private void StopCampfireSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
