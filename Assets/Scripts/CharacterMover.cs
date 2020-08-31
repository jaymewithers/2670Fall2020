using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    public float gravity = 9.81f;
    public float moveSpeed = 3f;
    public float fastMoveSpeed;
    public float jumpForce = 10f;
    public int jumpCountMax = 2;
    //public float rotateSpeed = 3f;
    //private Vector3 rotateMovement;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //rotateMovement.y = rotateSpeed * Input.GetAxis("Horizontal")*Time.deltaTime;
        //transform.Rotate(rotateMovement);
        //movement.x = Input.GetAxis("Horizontal") * moveSpeed;
        
        if (Input.GetButtonDown("Jump"))
        {
            movement.y = jumpForce;
        }

        if (controller.isGrounded)
        {
            movement.y = 0;
        }
        else
        {
            movement.y -= gravity;
        }

        //movement = transform.TransformDirection(movement);
        controller.Move(movement * Time.deltaTime);
    }
}