using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InstancerBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public Vector3Data rotationDirection;
    public float holdTime = 0.5f;
    public int instanceCount = 10;
    private int counter;

    public UnityEvent startEvent, onCallEvent, restartLoopEvent;
    
    private WaitForSeconds wfs;
    
    private void Start()
    {
        wfs = new WaitForSeconds(holdTime);
        startEvent.Invoke();
    }

    public void StartLoopEvents()
    {
        StartCoroutine(CallInstanceEvent());
    }

    private IEnumerator CallInstanceEvent()
    {
        while (counter < instanceCount)
        {
            onCallEvent.Invoke();
            counter++;
            yield return wfs;
        }
        counter = 0;
        restartLoopEvent.Invoke();
    }

    public void Instance()
    {
        var location = transform.position;
        Instantiate(prefab, location, Quaternion.Euler(rotationDirection.value));
    }
}