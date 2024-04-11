using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score = 0;
    private ScoreDisplay scoreDisplay;
    void Awake()
    {
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
        InitializeScoreDisplay();
        UpdateScoreDisplay();
    }

  
    void InitializeScoreDisplay()
    {
        GameObject scoreDisplayObject = GameObject.FindGameObjectWithTag("ScoreDisplay");
        if (scoreDisplayObject != null)
        {
            Debug.Log("ScoreDisplay GameObject found: " + scoreDisplayObject.name);
            scoreDisplay = scoreDisplayObject.GetComponent<ScoreDisplay>();
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
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreDisplay();
    }
}
