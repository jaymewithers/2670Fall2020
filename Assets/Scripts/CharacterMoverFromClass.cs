﻿using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMoverFromClass : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    public float rotateSpeed = 120f, gravity = -9.81f, jumpForce = 30f;
    private float yVar;

    public FloatData normalSpeed, fastSpeed;
    private FloatData moveSpeed;

    public IntData playerJumpCount;
    private int jumpCount;

    public Vector3Data currentSpawnPoint;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = normalSpeed;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = fastSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }
        
        var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
        movement.Set(vInput, yVar, 0);

        var hInput = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        transform.Rotate(0, hInput, 0);

        yVar += gravity * Time.deltaTime;

        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
        {
            yVar = jumpForce;
            jumpCount++;
        }

        movement = transform.TransformDirection(movement);
        controller.Move(movement* Time.deltaTime);
    }
    private void OnEnable()
    {
        transform.position = currentSpawnPoint.value;
    }
}