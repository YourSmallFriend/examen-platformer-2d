using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f; // Delay before the platform falls
    public float fallForce = 10f; // Force applied to the platform when falling

    private Rigidbody2D rb; // Reference to the platform's Rigidbody2D component
    private bool playerTouched = false; // Flag to track if the player has touched the platform

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get reference to the Rigidbody2D component
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !playerTouched)
        {
            playerTouched = true; // Set the flag to true when the player touches the platform
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay); // Wait for the specified delay

        // Apply a downward force to the platform to make it fall
        rb.bodyType = RigidbodyType2D.Dynamic; // Change the body type to Dynamic to enable physics
        rb.gravityScale = 1f; // Enable gravity to make the platform fall
        rb.velocity = new Vector2(0f, -fallForce); // Apply the falling force
    }
}
