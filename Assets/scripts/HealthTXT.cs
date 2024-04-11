using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public HealthManager healthManager;

    private TextMeshProUGUI healthText;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        if (healthManager == null)
        {
            Debug.LogWarning("HealthManager reference is not set in HealthDisplay script.");
            return;
        }
        UpdateHealthText();
    }

    void Update()
    {
        UpdateHealthText();
    }
    private void UpdateHealthText()
    {
        if (healthText == null)
        {
            Debug.LogWarning("TextMeshProUGUI component is not set in HealthDisplay script.");
            return;
        }
        healthText.text = "Health: " + healthManager.GetCurrentHealth().ToString();
    }
}
