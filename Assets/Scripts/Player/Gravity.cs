using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityForce = -9.81f;
    private Vector3 velocity;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        ApplyGravity();
    }

    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            velocity.y += gravityForce * Time.deltaTime;
        }
        else
        {
            velocity.y = -2f;  // Mantiene al personaje pegado al suelo
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
