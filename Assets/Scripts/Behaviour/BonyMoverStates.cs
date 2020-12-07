using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BonyMoverStates : MonoBehaviour
{
    public UnityEvent idleEvent, walkEvent, walkBackEvent, jumpEvent;
    private void Start()
    {
        idleEvent.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            walkEvent.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            walkBackEvent.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jump());
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            idleEvent.Invoke();
        }
    }

    private IEnumerator Jump()
    {
        jumpEvent.Invoke();
        yield return new WaitForSeconds(3);
        idleEvent.Invoke();
        StopCoroutine(Jump());
    }
}
