using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed

    private Animator anim;
    private Vector3 moveDirection;
    private float mouseSensitivity = 5f; // Mouse sensitivity
    private float yRotation = 0f;
    private CharacterController characterController;
    private PlayerHealth playerHealth; // Reference to PlayerHealth

    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerHealth = GetComponent<PlayerHealth>(); // Get player health script
        yRotation = transform.eulerAngles.y;

        // Lock and hide the mouse pointer
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (playerHealth.IsDead()) return; // Prevent movement if dead

        RotateWithMouse();
        Move(moveDirection);
    }

    void RotateWithMouse()
    {
        float mouseX = Mouse.current.delta.x.ReadValue();
        yRotation += mouseX * mouseSensitivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    public void OnMove(InputValue input)
    {
        if (playerHealth.IsDead()) return; // Block movement input if dead

        Vector2 inputVec = input.Get<Vector2>();
        moveDirection = new Vector3(inputVec.x, 0, inputVec.y);

        // Update Blend tree animation
        anim.SetFloat("moveX", inputVec.x);
        anim.SetFloat("moveY", inputVec.y);
    }

    void Move(Vector3 direction)
    {
        Vector3 move = transform.TransformDirection(direction);
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }
}
