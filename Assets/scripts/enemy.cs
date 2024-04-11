using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 5f;
    public float attackDamage = 10f;
    public Transform player;
    void Update()
    {
        MoveTowardsPlayer();
    }
    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
