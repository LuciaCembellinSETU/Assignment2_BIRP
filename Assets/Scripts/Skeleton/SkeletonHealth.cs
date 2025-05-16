using UnityEngine;
using Interfaces;

public class SkeletonHealth : MonoBehaviour, IDamageable
{
    public int maxHealth = 3;
    private int currentHealth;
    private bool isDead = false;

    private Animator anim;
    private SkeletonChase skeletonChase;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        skeletonChase = GetComponent<SkeletonChase>(); // Reference to Chase script
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        anim.SetTrigger("receiveDamage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("die");
        skeletonChase.StopChasing(); // Stops the chasing
        Destroy(gameObject, 7f); // Destroy the skeleton after 2 seconds
    }

    public bool IsDead()
    {
        return isDead;
    }
}
