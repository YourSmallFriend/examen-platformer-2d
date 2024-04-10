using UnityEngine;

public class obstakel : MonoBehaviour
{
    public float damageAmount = 10; // Amount of damage dealt by the enemy

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.collider.CompareTag("Player"))
        {
            // Get the HealthManager component from the player object
            HealthManager playerHealth = collision.gameObject.GetComponent<HealthManager>();

            // If the HealthManager component exists, deal damage to the player
            if (playerHealth != null)
            {
                // Convert the float damageAmount to an int before passing it to TakeDamage
                int damage = Mathf.RoundToInt(damageAmount);
                playerHealth.TakeDamage(damage);
            }
        }
    }
}

