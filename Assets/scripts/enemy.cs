using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of enemy movement
    public float attackRange = 5f; // Range within which the enemy will attack the player
    public float attackDamage = 10f; // Damage inflicted by the enemy's attack
    public Transform player; // Reference to the player's transform

    private bool isAttacking = false; // Flag to track if the enemy is attacking

    void Update()
    {
        // Check if the player is within attack range
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // If the player is within attack range, stop moving and start attacking
            isAttacking = true;
        }
        else
        {
            // If the player is not within attack range, move towards the player
            isAttacking = false;
            MoveTowardsPlayer();
        }
    }

    // Move the enemy towards the player
    void MoveTowardsPlayer()
    {
        // Calculate the direction towards the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the enemy horizontally towards the player
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    // Attack the player by dealing damage on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Inflict damage on the player
            // You can implement your damage logic here
            // For example, reduce the player's health
            Debug.Log("Enemy attacked player!");

            // After attacking, stop moving and reset attack flag
            isAttacking = false;
        }
    }
}
