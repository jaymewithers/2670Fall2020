﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterKnockBack : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move = Vector3.left;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Update()
    {
        controller.Move(move * Time.deltaTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        var i = 2f;
        move = other.attachedRigidbody.velocity * i;

        while (i > 0)
        {
            yield return new WaitForFixedUpdate();
            i -= 0.1f;
        }
        
        move = Vector3.left;
    }
}