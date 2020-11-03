using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PushPullRBody : MonoBehaviour
{
    private Rigidbody rBody;
    public bool canPickup;
    public Transform player;
    public Vector3 offset;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (canPickup && Input.GetKeyDown(KeyCode.Z))
        {
            var transformObj = transform;
            transformObj.position = player.position + offset;
            transformObj.parent = player;
            canPickup = false;
        }

        if (!canPickup && Input.GetKeyUp(KeyCode.Z))
        {
            var transformObj = transform;
            transformObj.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        offset = other.transform.position;
        player = other.transform;
        canPickup = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }


    // public bool canPush;
    // public Transform player;
    // public Vector3 offsetPosition, newPosition;
    // public UnityEvent onPush, onLetGo;
    //
    // private IEnumerator OnTriggerEnter(Collider other)
    // {
    //     onPush.Invoke();
    //     offsetPosition = transform.position;
    //     yield return new WaitForFixedUpdate();
    //     canPush = true;
    //     while (canPush)
    //     {
    //         yield return new WaitForFixedUpdate();
    //         newPosition = player.position + offsetPosition;
    //         transform.position = newPosition;
    //         other.transform.rotation = Quaternion.Euler(0,0,0);
    //     }
}