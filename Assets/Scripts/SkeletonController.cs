using UnityEngine;
using UnityEngine.AI;
using Interfaces;

public class SkeletonController : MonoBehaviour, IDamageable
{
    // Variables de salud
    public int maxHealth = 3;
    private int currentHealth;
    private bool isDead = false;

    // Variables de IA y animaci�n
    private GameObject player;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isChasing = false;
    private float attackRange = 2f;
    private float attackCooldown = 1f; // Tiempo de espera entre ataques
    private float lastAttackTime = 0f; // �ltimo ataque realizado

    // Referencia al script de ataque
    private SkeletonAttack skeletonAttack;

    void Start()
    {
        // Inicializaci�n de componentes
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        skeletonAttack = GetComponent<SkeletonAttack>(); // Obtiene el script de ataque
    }

    void Update()
    {
        if (isDead) return; // Si est� muerto, no hace nada

        if (isChasing)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer > attackRange)
            {
                agent.SetDestination(player.transform.position);
                anim.SetBool("isRunning", true);
            }
            else
            {
                agent.ResetPath(); // Detiene el movimiento
                anim.SetBool("isRunning", false);

                // Verifica si ha pasado suficiente tiempo desde el �ltimo ataque
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    skeletonAttack.Attack(); // Llama al ataque
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    public void StartChasing()
    {
        if (isDead) return; // No persigue si est� muerto
        isChasing = true;
        anim.SetBool("isRunning", true);
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
        isChasing = false;
        agent.ResetPath(); // Detiene el movimiento
        anim.SetTrigger("die"); // Activa animaci�n de muerte
    }
}
