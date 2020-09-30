﻿using System.Collections;
using UnityEngine;

public class CharacterKnockBack : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 knockBackVector;
    public float knockBackForce = 5f;
    private float tempForce;
    
    private void Start()
    {
        tempForce = knockBackForce;
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        knockBackForce = tempForce;
        while (knockBackForce > 0)
        {
            knockBackVector.x = knockBackForce * Time.deltaTime;
            controller.Move(knockBackVector);
            knockBackForce -= 0.1f;
            yield return new WaitForFixedUpdate();
        }
    }
}