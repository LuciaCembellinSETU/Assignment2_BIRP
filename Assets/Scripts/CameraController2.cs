using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float sphereCastRadius = 0.3f;
    public float maxDistance = 5f;
    public float minDistance = 1f;
    public Vector3 offset = new Vector3(0, 4f, -5f);
    public LayerMask obstacleLayers;
    public float verticalAdjustment = 1.5f;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (!player) return;

        // Punto objetivo ideal
        Vector3 desiredPosition = player.position + player.TransformDirection(offset.normalized) * maxDistance;

        // Dirección desde el jugador al objetivo
        Vector3 direction = (desiredPosition - player.position).normalized;

        RaycastHit hit;

        Vector3 finalPosition = desiredPosition;

        if (Physics.SphereCast(player.position, sphereCastRadius, direction, out hit, maxDistance, obstacleLayers))
        {
            float adjustedDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
            finalPosition = player.position + direction * adjustedDistance;

            // Aquí aplicamos el levantamiento vertical
            float distanceFactor = 1 - (adjustedDistance / maxDistance); // 0 cerca, 1 lejos
            float heightOffset = verticalAdjustment * distanceFactor;
            finalPosition += Vector3.up * heightOffset;
        }

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref currentVelocity, 0.05f);

        // Siempre mirar al jugador con un ligero desplazamiento hacia arriba
        transform.LookAt(player.position + Vector3.up * 1.2f);
    }
}
