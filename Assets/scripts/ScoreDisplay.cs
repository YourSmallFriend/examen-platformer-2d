using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI scoreText; // Reference to the TextMeshPro component

    void Start()
    {
        // Get the TextMeshPro component attached to this GameObject
        scoreText = GetComponent<TextMeshProUGUI>();

        // Initialize the score text
        UpdateScoreDisplay(0);
    }

    // Method to update the score display
    public void UpdateScoreDisplay(int score)
    {
        // Update the text to display the current score
        scoreText.text = "Score: " + score;
    }
}
