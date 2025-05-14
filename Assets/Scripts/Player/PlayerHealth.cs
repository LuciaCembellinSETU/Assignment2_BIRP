using UnityEngine;
using UnityEngine.UI; // Necesario si usas una barra de vida en la UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    
    private int currentHealth;
    public Image healthBar; // Para actualizar la barra de vida (opcional)

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        // UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"I got a damage of {damage}");

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        // TODO - Health bar
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("The player has died");
        // TODO - Death logic and implementation
    }
}
