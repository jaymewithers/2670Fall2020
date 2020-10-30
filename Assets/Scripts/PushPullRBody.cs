using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PushPullRBody : MonoBehaviour
{
    public Transform player, obj;
    public bool canPush;
    public Vector3 newPosition, offset;

    private void OnTriggerEnter(Collider other)
    {
        canPush = true;
        StartCoroutine(OnPush());
    }

    private IEnumerator OnPush()
    {
        print("Started Coroutine");
        yield return new WaitForFixedUpdate();
        while (canPush)
        {
            newPosition = player.transform.position + offset;
            obj.transform.position = newPosition;
        }
    }
}
// public bool canDrag;
    // public UnityEvent dragEvent, stopDragEvent;
    //
    // private void OnTriggerEnter(Collider other)
    // {
    //     canDrag = true;
    //     if (canDrag)
    //     {
    //         dragEvent.Invoke();
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     canDrag = false;
    //     stopDragEvent.Invoke();
    // }

//other.transform.parent = player.transform;