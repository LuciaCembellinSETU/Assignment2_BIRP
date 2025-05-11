using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public AttackArea attackArea;

    private Animator anim; // Animator
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnAttack(InputValue value)
    {
        if (!isAttacking)
        {
            // Hit the enemies
            Hit();
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

    // Add an animation event to end attack
    public void EndAttack()
    {
        isAttacking = false;
    }
}
