using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    private Transform player;
    private Transform cameraTransform;
    public float maxDistance = 4f;
    public float minDistance = 1f;
    public float sphereRadius = 0.5f;
    public LayerMask obstacleMask;
    public float smoothSpeed = 5f;

    void Start()
    {
        cameraTransform = transform;
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player'. Verifica que el personaje tenga la etiqueta correcta.");
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredLocalPosition = new Vector3(0, 2, -maxDistance);
        Vector3 worldDesiredPosition = player.TransformPoint(desiredLocalPosition);

        RaycastHit[] hits = Physics.SphereCastAll(player.position, sphereRadius,
            (worldDesiredPosition - player.position).normalized, maxDistance, obstacleMask);

        float newDistance = maxDistance;

        // Evaluamos todas las colisiones para obtener el punto más cercano
        foreach (RaycastHit hit in hits)
        {
            float hitDistance = Vector3.Distance(player.position, hit.point);
            newDistance = Mathf.Clamp(hitDistance - 0.5f, minDistance, maxDistance);
        }

        // Prevenir el "salto" de la cámara a la posición máxima en caso de error en colisiones
        if (newDistance > cameraTransform.localPosition.z && newDistance < maxDistance)
        {
            newDistance = Mathf.Lerp(cameraTransform.localPosition.z, newDistance, Time.deltaTime * smoothSpeed);
        }

        // Aplicamos la nueva posición suavemente
        Vector3 smoothPosition = Vector3.Lerp(cameraTransform.localPosition, new Vector3(0, 2, -newDistance), Time.deltaTime * smoothSpeed);
        cameraTransform.localPosition = smoothPosition;
    }
}
