using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public int damage = 1; // Damage inflicted by the skeleton
    private AttackArea attackArea; // Attack area

    private Animator anim;
    private bool isAttacking = false;
    private GameObject player; // Player reference
    private Collider playerCollider; // Player's collider
    private PlayerHealth playerHealth; // Player's health reference

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player"); // Find the player by tag
        attackArea = GetComponentInChildren<AttackArea>(); // Find the attack area inside the skeleton

        if (player != null)
        {
            playerCollider = player.GetComponent<Collider>(); // Get the player's collider
            playerHealth = player.GetComponent<PlayerHealth>(); // Get the player's health script
        }
        else
        {
            Debug.LogError("No object with the 'Player' tag was found.");
        }

        if (attackArea == null)
        {
            Debug.LogError("No 'AttackArea' component found inside the skeleton.");
        }
    }

    public void Attack()
    {
        if (playerHealth != null && playerHealth.IsDead()) return; // Stop attacking if the player is dead

        if (!isAttacking)
        {
            Hit();
            anim.SetTrigger("attack"); // Trigger attack animation
        }
    }

    private void Hit()
    {
        isAttacking = true;

        if (playerHealth != null && playerHealth.IsDead()) return; // Stop dealing damage if the player is dead

        if (player != null && attackArea != null && attackArea.GetComponent<Collider>().bounds.Intersects(playerCollider.bounds))
        {
            playerHealth.Damage(damage); // Inflict damage on the player
        }
    }

    // Animation event to end the attack
    public void EndAttack()
    {
        isAttacking = false;
    }
}
