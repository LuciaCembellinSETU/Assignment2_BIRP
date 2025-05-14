using UnityEngine;
using UnityEngine.AI;

public class SkeletonChase : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    private Animator anim;
    private SkeletonAttack skeletonAttack;
    private SkeletonHealth skeletonHealth;

    private bool isChasing = false;
    private float attackRange = 2f;
    private float attackCooldown = 1f;
    private float lastAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        skeletonAttack = GetComponent<SkeletonAttack>();
        skeletonHealth = GetComponent<SkeletonHealth>();
    }

    void Update()
    {
        if (skeletonHealth.IsDead()) return; // Si está muerto, no hace nada

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
                agent.ResetPath();
                anim.SetBool("isRunning", false);

                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    skeletonAttack.Attack();
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    public void StartChasing()
    {
        if (skeletonHealth.IsDead()) return; // No persigue si está muerto
        isChasing = true;
        anim.SetBool("isRunning", true);
    }

    public void StopChasing()
    {
        isChasing = false;
        agent.ResetPath();
        anim.SetBool("isRunning", false);
    }
}
