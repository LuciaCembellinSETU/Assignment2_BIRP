using UnityEngine;

public class FollowTerrain : MonoBehaviour
{
    public LayerMask terrainLayer; // Capa del terreno
    public float raycastDistance = 2f; // Distancia del Raycast
    public float gravityForce = 10f; // Fuerza de gravedad personalizada
    public float groundOffset = 0.1f; // Ajuste para que no atraviese el terreno

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivamos la gravedad de Unity para manejarla manualmente
    }

    void Update()
    {
        RaycastHit hit;

        // Lanza un Raycast hacia abajo desde el personaje
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, terrainLayer))
        {
            // Calcula la nueva posición ajustada
            float targetY = hit.point.y + groundOffset;

            // Aplicamos una fuerza de gravedad hacia el terreno
            if (transform.position.y > targetY)
            {
                rb.velocity += Vector3.down * gravityForce * Time.deltaTime;
            }
            else
            {
                // Ajustamos la posición directamente cuando toca el suelo
                Vector3 newPosition = new Vector3(transform.position.x, targetY, transform.position.z);
                transform.position = newPosition;
                rb.velocity = Vector3.zero; // Detenemos el movimiento vertical
            }
        }
    }
}
