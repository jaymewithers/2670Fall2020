using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PushPullRBody : MonoBehaviour
{
    public bool canPush;
    public Transform player;
    private Vector3 offsetPosition, newPosition;
    public UnityEvent onPush, onLetGo;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        onPush.Invoke();
        offsetPosition = transform.position;
        yield return new WaitForFixedUpdate();
        canPush = true;
        while (canPush)
        {
            yield return new WaitForFixedUpdate();
            newPosition = player.position + offsetPosition;
            transform.position = newPosition;
            other.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}