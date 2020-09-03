using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMoverFromClass : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    public float moveSpeed = 5f, fastMoveSpeed = 10f, rotateSpeed = 120f, gravity = -9.81f, jumpForce = 30f;
    private float yVar;

    public int jumpCountMax = 2;
    private int jumpCount;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        var vInput = Input.GetAxis("Vertical") * moveSpeed;
        movement.Set(vInput, yVar, 0);

        var hInput = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        transform.Rotate(0, hInput, 0);

        yVar += gravity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            moveSpeed = fastMoveSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            moveSpeed = 5f;
        }

        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            yVar = jumpForce;
            jumpCount++;
        }

        movement = transform.TransformDirection(movement);
        controller.Move(movement* Time.deltaTime);
    }
}