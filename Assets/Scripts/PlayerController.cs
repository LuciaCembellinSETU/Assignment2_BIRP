using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;    // Player speed
    

    // Camera movement
    private Animator anim;
    private Vector3 moveDirection;
    private float mouseSensitivity = 20f;    // Sensibility for the mouse
    private float yRotation = 0f;

    // Attack
    bool isAttacking = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Get the initial rotation for the player
        yRotation = transform.eulerAngles.y;

        // Block and disable mouse pointer
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
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
        Vector2 inputVec = input.Get<Vector2>();
        moveDirection = new Vector3(inputVec.x, 0, inputVec.y);

        // Update Blend tree
        anim.SetFloat("moveX", inputVec.x);
        anim.SetFloat("moveY", inputVec.y);
    }

    void Move(Vector3 direction)
    {
        Vector3 move = transform.TransformDirection(direction);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    public void OnAttack(InputValue value)
    {
        if (!isAttacking)
        {
            anim.SetTrigger("attack");
            isAttacking = true;

            // TODO - Implement damage the enemies
        }
    }

    // Add an animation event to end attack
    public void EndAttack()
    {
        isAttacking = false;
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

}
