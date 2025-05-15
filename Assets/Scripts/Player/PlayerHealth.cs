using UnityEngine;
using UnityEngine.UI; // Required if using a health bar in the UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maximum health
    private int currentHealth;
    private Animator anim;
    public Image healthBar; // Health bar reference (optional)
    private bool isDead = false; // Tracks if the player is dead
    public float deathSceneDelay = 2f; // Time before switching to GameOver scene

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
        if (isDead) return; // Prevent multiple calls to Die()

        isDead = true; // Ensure player is marked as dead
        anim.SetTrigger("die"); // Play death animation

        Debug.Log("Player is dead. Scene will change after delay.");

        if (GameManager.Instance != null)
        {
            Invoke(nameof(TriggerGameOverScene), deathSceneDelay); // Wait before changing scene
        }
        else
        {
            Debug.LogError("GameManager.Instance is missing!");
        }
    }

    void TriggerGameOverScene()
    {
        GameManager.Instance.LoadGameOver();
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
