using UnityEngine;

public class FollowTerrain : MonoBehaviour
{
    public LayerMask terrainLayer; // Terrain layer

    private Rigidbody rb;
    private float raycastDistance = 2f; // Raycast distance

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit hit;
        // Throws a Raycast to the ground
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, terrainLayer))
        {
            // Adjust the position
            Vector3 newPosition = hit.point; // Contact point with terrain
            newPosition.y += 0.1f; // Adjust
            transform.position = newPosition;
        }
    }
}
