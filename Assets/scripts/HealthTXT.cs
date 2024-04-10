using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public HealthManager healthManager; // Reference to the HealthManager script

    private TextMeshProUGUI healthText; // Reference to the TextMeshPro text component

    void Start()
    {
        // Get reference to the TextMeshPro text component
        healthText = GetComponent<TextMeshProUGUI>();

        // Ensure the healthManager reference is set
        if (healthManager == null)
        {
            Debug.LogWarning("HealthManager reference is not set in HealthDisplay script.");
            return;
        }

        // Update the health text initially
        UpdateHealthText();
    }

    void Update()
    {
        // Update the health text if it's changed
        UpdateHealthText();
    }

    // Method to update the health text with the current player's health value
    private void UpdateHealthText()
    {
        // Ensure the healthText reference is set
        if (healthText == null)
        {
            Debug.LogWarning("TextMeshProUGUI component is not set in HealthDisplay script.");
            return;
        }

        // Update the health text with the current player's health value
        healthText.text = "Health: " + healthManager.GetCurrentHealth().ToString();
    }
}
