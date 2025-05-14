using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public int damage = 1; // Daño que inflige el esqueleto
    private AttackArea attackArea; // Área de ataque

    private Animator anim;
    private bool isAttacking = false;
    private GameObject player; // Referencia al jugador
    private Collider playerCollider; // Collider del jugador

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player"); // Busca al jugador por etiqueta
        attackArea = GetComponentInChildren<AttackArea>(); // Busca el área de ataque dentro del esqueleto

        if (player != null)
        {
            playerCollider = player.GetComponent<Collider>(); // Obtiene el collider del jugador
        }
        else
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player'.");
        }

        if (attackArea == null)
        {
            Debug.LogError("No se encontró el componente AttackArea dentro del esqueleto.");
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.SetTrigger("attack"); // Activa la animación de ataque
        }
    }

    private void Hit()
    {
        if (player != null && attackArea != null && attackArea.GetComponent<Collider>().bounds.Intersects(playerCollider.bounds))
        {
            Debug.Log("El esqueleto golpeó al jugador.");
            // Aquí puedes llamar a la función que reduce la vida del jugador
        }
    }

    // Evento de animación para finalizar el ataque
    public void EndAttack()
    {
        isAttacking = false;
    }
}
