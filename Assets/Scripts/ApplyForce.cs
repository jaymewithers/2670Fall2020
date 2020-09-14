﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    private Rigidbody rBody;
    public float force = 30f;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        var forceDirection = new Vector3(force, 0, 0);
        // forceDirection needs to be based on player rotation (hint scriptable object)
        rBody.AddRelativeForce(forceDirection);
    }
}