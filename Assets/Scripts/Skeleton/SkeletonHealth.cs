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
        skeletonChase = GetComponent<SkeletonChase>(); // Referencia al script de persecución
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log($"Skeleton recibió daño. Vida restante: {currentHealth}");

        anim.SetTrigger("receiveDamage"); // Activa animación de daño

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("die"); // Activa animación de muerte
        skeletonChase.StopChasing(); // Detiene la persecución
        gameObject.tag = "DeadEnemy"; // Cambia el tag para evitar futuras interacciones
        Destroy(gameObject, 5f); // Destruye el objeto después de 5 segundos
    }

    public bool IsDead()
    {
        return isDead;
    }
}
