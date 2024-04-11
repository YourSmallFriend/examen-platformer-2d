using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;
    private bool canTakeDamage = true;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public void TakeDamage(int damage)
    {
        if (!canTakeDamage)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth < 1)
        {
            currentHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        animator.SetBool("Damage", true);
        canTakeDamage = false;

        Invoke("ResetDamageCooldown", 0.5f);
        Invoke("ResetDamageAnimation", 0.4f);
    }
    private void ResetDamageCooldown()
    {
        canTakeDamage = true;
    }
    private void ResetDamageAnimation()
    {
        animator.SetBool("Damage", false);
    }
}
