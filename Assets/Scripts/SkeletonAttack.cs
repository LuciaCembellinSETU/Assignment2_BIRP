using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public int damage = 1; // Da�o que inflige el esqueleto
    private AttackArea attackArea; // �rea de ataque

    private Animator anim;
    private bool isAttacking = false;
    private GameObject player; // Referencia al jugador
    private Collider playerCollider; // Collider del jugador

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player"); // Busca al jugador por etiqueta
        attackArea = GetComponentInChildren<AttackArea>(); // Busca el �rea de ataque dentro del esqueleto

        if (player != null)
        {
            playerCollider = player.GetComponent<Collider>(); // Obtiene el collider del jugador
        }
        else
        {
            Debug.LogError("No se encontr� un objeto con la etiqueta 'Player'.");
        }

        if (attackArea == null)
        {
            Debug.LogError("No se encontr� el componente AttackArea dentro del esqueleto.");
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.SetTrigger("attack"); // Activa la animaci�n de ataque
        }
    }

    private void Hit()
    {
        if (player != null && attackArea != null && attackArea.GetComponent<Collider>().bounds.Intersects(playerCollider.bounds))
        {
            Debug.Log("El esqueleto golpe� al jugador.");
            // Aqu� puedes llamar a la funci�n que reduce la vida del jugador
        }
    }

    // Evento de animaci�n para finalizar el ataque
    public void EndAttack()
    {
        isAttacking = false;
    }
}
