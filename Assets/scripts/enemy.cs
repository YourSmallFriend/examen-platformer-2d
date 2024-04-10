using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of enemy movement
    public float attackRange = 5f; // Range within which the enemy will attack the player
    public float attackDamage = 10f; // Damage inflicted by the enemy's attack
    public Transform player; // Reference to the player's transform
    void Update()
    {
        MoveTowardsPlayer();
    }

    // Move the enemy towards the player
    void MoveTowardsPlayer()
    {
        // Calculate the direction towards the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the enemy horizontally towards the player
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
