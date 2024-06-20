using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool eggsCollected = false;
    private bool eggsGiven = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool AreEggsCollected()
    {
        return eggsCollected;
    }

    public void SaveEggsCollected(bool collected)
    {
        eggsCollected = collected;
        // Tutaj mo¿esz zapisaæ stan zebranych jajek w pamiêci gry
    }

    public bool AreEggsGiven()
    {
        return eggsGiven;
    }

    public void SaveEggsGiven(bool given)
    {
        eggsGiven = given;
        // Tutaj mo¿esz zapisaæ stan oddanych jajek w pamiêci gry
    }
}
