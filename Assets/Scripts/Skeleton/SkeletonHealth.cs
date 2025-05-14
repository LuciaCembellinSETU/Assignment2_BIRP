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
        skeletonChase = GetComponent<SkeletonChase>(); // Referencia al script de persecuci�n
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log($"Skeleton recibi� da�o. Vida restante: {currentHealth}");

        anim.SetTrigger("receiveDamage"); // Activa animaci�n de da�o

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("die"); // Activa animaci�n de muerte
        skeletonChase.StopChasing(); // Detiene la persecuci�n
        gameObject.tag = "DeadEnemy"; // Cambia el tag para evitar futuras interacciones
        Destroy(gameObject, 5f); // Destruye el objeto despu�s de 5 segundos
    }

    public bool IsDead()
    {
        return isDead;
    }
}
