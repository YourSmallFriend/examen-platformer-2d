using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player
    private int currentHealth; // Current health of the player
    private Animator animator; // Reference to the Animator component
    private bool canTakeDamage = true; // Flag to track whether the player can take damage

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
        animator = GetComponent<Animator>(); // Get reference to the Animator component
    }

    // Method to get the current health
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Method to apply damage to the player
    public void TakeDamage(int damage)
    {
        // Check if the player can take damage (cooldown)
        if (!canTakeDamage)
        {
            return; // Exit the method if the player can't take damage yet
        }

        // Reduce current health by the damage amount
        currentHealth -= damage;

        // Ensure current health doesn't go below zero
        if (currentHealth < 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Play the damage animation
        animator.SetBool("Damage", true);

        // Set the cooldown flag to false to prevent taking damage for 0.5 seconds
        canTakeDamage = false;

        // Restart the cooldown after 0.5 seconds
        Invoke("ResetDamageCooldown", 0.5f);

        // Reset the damage animation after 0.4 seconds
        Invoke("ResetDamageAnimation", 0.4f);
    }

    // Method to reset the damage cooldown
    private void ResetDamageCooldown()
    {
        canTakeDamage = true;
    }

    // Method to reset the damage animation
    private void ResetDamageAnimation()
    {
        animator.SetBool("Damage", false);
    }
}
