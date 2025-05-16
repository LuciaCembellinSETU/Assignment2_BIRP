using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    private Animator anim;
    private bool isDead = false;
    public float deathSceneDelay = 2f;

    public Image healthBarFill; // HealthBar
    public Sprite greenBar, orangeBar, redBar; // Sprites for the colors

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthBarFill != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;

            // Cambiar el sprite de la barra según el nivel de salud
            if (healthPercentage > 0.5f)
            {
                healthBarFill.sprite = greenBar;
            }
            else if (healthPercentage > 0.25f)
            {
                healthBarFill.sprite = orangeBar;
            }
            else
            {
                healthBarFill.sprite = redBar;
            }

            // Ajustar el relleno de la barra de vida
            healthBarFill.fillAmount = healthPercentage;

        }
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Mi vida actual es: {currentHealth}");
        anim.SetTrigger("receiveDamage");

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        anim.SetTrigger("die");

        if (GameManager.Instance != null)
        {
            Invoke(nameof(TriggerGameOverScene), deathSceneDelay);
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
        return isDead;
    }
}
