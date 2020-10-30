using UnityEngine;
using UnityEngine.Events;

public class PushPullRBody : MonoBehaviour
{
    public bool canDrag;
    public UnityEvent dragEvent, stopDragEvent;

    private void OnTriggerEnter(Collider other)
    {
        canDrag = true;
        if (canDrag)
        {
            dragEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canDrag = false;
        stopDragEvent.Invoke();
    }
}

//other.transform.parent = player.transform;