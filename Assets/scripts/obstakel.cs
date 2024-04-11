using UnityEngine;

public class obstakel : MonoBehaviour
{
    public float damageAmount = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            HealthManager playerHealth = collision.gameObject.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                int damage = Mathf.RoundToInt(damageAmount);
                playerHealth.TakeDamage(damage);
            }
        }
    }
}

