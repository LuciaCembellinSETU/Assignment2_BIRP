using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void RecieveDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            anim.SetTrigger("recieveDamage"); // Activa la animación de daño

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("die"); // Activa la animación de muerte
        GetComponent<Collider>().enabled = false; // Desactiva el collider para evitar más golpes
        // Destroy(gameObject, 3f); // Destruye el enemigo tras 3 segundos
    }
}
