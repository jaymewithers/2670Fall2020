using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class OldCharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    public float gravity = 9.81f;
    public float moveSpeed = 3f;
    public float fastMoveSpeed = 20f;
    public float jumpForce = 30f;
    public int jumpCountMax = 1;
    public int jumpCount;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            moveSpeed = fastMoveSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            moveSpeed = 3f;
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            jumpForce = 0;
        }

        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            jumpForce = 30f;
        }

        if (Input.GetButtonDown("Jump") && jumpCount <= jumpCountMax)
        {
            movement.y = jumpForce;
            jumpCount++;
        }

        if (controller.isGrounded)
        {
            movement.y = 0;
            jumpCount = 0;
        }
        else
        {
            movement.y -= gravity;
        }
        
        controller.Move(movement * Time.deltaTime);
    }
}