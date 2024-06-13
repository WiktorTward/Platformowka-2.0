using UnityEngine;
using UnityEngine.UI;

public class Game_manager_nachos : MonoBehaviour
{
    public static Game_manager_nachos Instance;
    public Text scoreNachosText;
    public Text scoreThumbnailText;
    public Text timerText;
    public float gameTime = 60f;
    private int scoreN = 0;
    private int scoreT = 0;
    private float timeRemaining;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("GameManager instance created");
        }
        else
        {
            Debug.LogWarning("Multiple instances of GameManager detected. Destroying duplicate.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timeRemaining = gameTime;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            EndGame();
        }
    }

    public void AddPointNachos()
    {
        scoreN++;
        Debug.Log("+1 PointNachos");
        scoreNachosText.text = "Score Nachos: " + scoreN.ToString();
    }

    public void AddPointThumbnail()
    {
        scoreT++;
        Debug.Log("+1 PointThumbnail");
        scoreThumbnailText.text = "Score Thumbnail: " + scoreT.ToString();
    }

    void EndGame()
    {
        Debug.Log("Game Over! Final Score Nachos: " + scoreN + " Final Score Thumbnail: " + scoreT);
        // Add additional end game logic here, e.g., display a game over screen
    }
}
