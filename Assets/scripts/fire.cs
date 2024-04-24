using UnityEngine;

public class fire : MonoBehaviour
{
    public int damageAmount = 5; // Amount of damage dealt by the fire trap
    private HealthManager playerHealth; // Reference to the player's HealthManager component
    private bool hasCollided = false; // Flag to track if the player has collided with the fire trap

    void Start()
    {
        // Find and store a reference to the player's HealthManager component
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player and hasn't occurred yet
        if (collision.collider.CompareTag("Player") && !hasCollided)
        {
            // Set the flag to true to prevent multiple collisions
            hasCollided = true;

            // Deal damage to the player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Start the fire animation
            StartFireAnimation();
        }
    }

    // Method to start the fire animation
    void StartFireAnimation()
    {
        // Get the Animator component of the player
        Animator playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        // Set the "fire" boolean parameter in the player's animator to true
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("fire", true);
        }
    }
}
