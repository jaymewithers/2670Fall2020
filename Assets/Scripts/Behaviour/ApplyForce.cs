﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    private Rigidbody rBody;
    public float force = 500f;

    public void Start()
    {
        rBody = GetComponent<Rigidbody>();
        var forceDirection = new Vector3(force, 0, 0);
        rBody.AddRelativeForce(forceDirection);
    }
}