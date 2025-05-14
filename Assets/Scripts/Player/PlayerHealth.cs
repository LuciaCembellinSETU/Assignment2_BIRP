using UnityEngine;
using UnityEngine.UI; // Required if using a health bar in the UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maximum health
    private int currentHealth;
    private Animator anim;
    public Image healthBar; // Health bar reference (optional)
    private bool isDead = false; // Tracks if the player is dead

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void Damage(int damage)
    {
        if (isDead) return; // If dead, ignore damage

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"My current health is: {currentHealth}");
        anim.SetTrigger("receiveDamage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return; // Can't heal if dead

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("die"); // Triggers death animation
    }

    public bool IsDead()
    {
        return isDead; // Allows other scripts to check if the player is dead
    }

    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
