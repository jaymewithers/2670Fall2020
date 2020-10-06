﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterKnockBack : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 move = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Update()
    {
        controller.Move(move * Time.deltaTime);
    }
    
    private IEnumerator KnockBack (ControllerColliderHit hit)
    {
        var i = 2f;
       move = hit.collider.attachedRigidbody.velocity * i;

        while (i > 0)
        {
            yield return new WaitForFixedUpdate();
            i -= 0.1f;
        }

        move = Vector3.zero;
    }

    public float pushPower = 10f;

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

        StartCoroutine(KnockBack(hit));
        
        var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        var forces = pushDir * pushPower;
        body.AddRelativeForce(forces);
        body.AddTorque(forces);
    }
}