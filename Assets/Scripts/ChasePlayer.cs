using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isChasing = false;
    private float attackRange = 1.5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isChasing)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer > attackRange)
            {
                agent.SetDestination(player.transform.position);
                animator.SetBool("isAttacking", false); // Asegura que no est� atacando
                animator.SetBool("isRunning", true); // Activa animaci�n de correr
            }
            else
            {
                agent.ResetPath(); // Detiene el movimiento
                animator.SetBool("isRunning", false); // Desactiva animaci�n de correr
                animator.SetBool("isAttacking", true); // Activa animaci�n de ataque
            }
        }
    }

    public void StartChasing()
    {
        isChasing = true;
        animator.SetBool("isRunning", true); // Activa animaci�n de correr al empezar la persecuci�n
    }
}
