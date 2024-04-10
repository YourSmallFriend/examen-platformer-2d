using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Value of the coin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Add coin value to the player's score
            GameManager.instance.AddScore(coinValue);

            // Destroy the coin GameObject
            Destroy(gameObject);
        }
    }
}
