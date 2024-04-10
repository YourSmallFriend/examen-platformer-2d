using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    private int score = 0; // Current player score
    private ScoreDisplay scoreDisplay; // Reference to the ScoreDisplay script

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize score display
        InitializeScoreDisplay();
        UpdateScoreDisplay();
    }

    // Method to initialize score display
    void InitializeScoreDisplay()
    {
        // Find the ScoreDisplay GameObject by tag
        GameObject scoreDisplayObject = GameObject.FindGameObjectWithTag("ScoreDisplay");

        // Check if the ScoreDisplay GameObject was found
        if (scoreDisplayObject != null)
        {
            Debug.Log("ScoreDisplay GameObject found: " + scoreDisplayObject.name);

            // Get the ScoreDisplay component from the GameObject
            scoreDisplay = scoreDisplayObject.GetComponent<ScoreDisplay>();

            // If the ScoreDisplay component exists, update the score display
            if (scoreDisplay != null)
            {
                Debug.Log("ScoreDisplay component found.");
            }
            else
            {
                Debug.LogWarning("ScoreDisplay component not found on ScoreDisplay GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("ScoreDisplay GameObject not found.");
        }
    }

    // Method to update the score display
    public void UpdateScoreDisplay()
    {
        if (scoreDisplay != null)
        {
            scoreDisplay.UpdateScoreDisplay(score);
        }
        else
        {
            Debug.LogWarning("ScoreDisplay reference is null. Score was updated but the display is not updated.");
        }
    }

    // Method to add score
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreDisplay();
    }
}
