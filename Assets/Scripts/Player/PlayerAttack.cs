using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public AttackArea attackArea;

    private Animator anim; // Animator reference
    private bool isAttacking = false;
    private PlayerHealth playerHealth; // Reference to PlayerHealth

    void Start()
    {
        anim = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>(); // Get player health script
    }

    public void OnAttack(InputValue value)
    {
        if (playerHealth.IsDead()) return; // Prevent attacking if dead

        if (!isAttacking)
        {
            Hit(); // Execute attack
            anim.SetTrigger("attack");
        }
    }

    private void Hit()
    {
        isAttacking = true;
        foreach (var attackAreaDamageable in attackArea.Damageables)
        {
            attackAreaDamageable.Damage(damage);
        }
    }

    // Animation event to end attack
    public void EndAttack()
    {
        isAttacking = false;
    }
}
