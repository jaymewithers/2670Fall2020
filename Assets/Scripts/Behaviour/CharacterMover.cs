﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    public float rotateSpeed = 120f, gravity = -9.81f, jumpForce = 10f;
    private float yVar;

    public FloatData normalSpeed, fastSpeed;
    private FloatData moveSpeed;
    private bool canMove = true;

    public IntData playerJumpCount;
    private int jumpCount;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = normalSpeed;
        StartCoroutine(Move());
    }

    private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    private IEnumerator Move()
    {
        canMove = true;
        while (canMove)
        {
            yield return wffu;
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
            controller.Move(movement * Time.deltaTime);
        }
    }

    private IEnumerator KnockBack(ControllerColliderHit hit, Rigidbody body)
    {
        canMove = false;
        var i = 2f;
        movement = -hit.moveDirection;
        movement.y = -1;
        while (i > 0)
        {
            yield return wffu;
            i -= 0.1f;
            controller.Move((movement) * Time.deltaTime);
            
            var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            var forces = pushDir * pushPower;
            body.AddForce(forces);
        }
        movement = Vector3.zero;
        StartCoroutine(Move());
    }
    
    public float pushPower = 10.0f;
    //private CharacterController characterController;
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        StartCoroutine(KnockBack(hit, body));
    }
}