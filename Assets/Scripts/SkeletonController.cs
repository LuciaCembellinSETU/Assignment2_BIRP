using Interfaces;
using UnityEngine;

public class SkeletonController : MonoBehaviour, IDamageable
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

    public void Damage(int damage)
    {
        if (!isDead)
        {
            Debug.Log($"Current health {currentHealth}");

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }

            anim.SetTrigger("receiveDamage"); // Triggers receive damage animation
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("die"); // Triggers the death animation
    }
}
