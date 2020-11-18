using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, onEnable, awakeEvent;
    public float holdTime = 0.001f;

    public bool repeatOnStart;
    
    private void Awake()
    {
        awakeEvent.Invoke();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(holdTime);
        startEvent.Invoke();

        while (repeatOnStart)
        {
            yield return new WaitForSeconds(holdTime);
            startEvent.Invoke();
        }
    }

    private void OnEnable()
    {
        onEnable.Invoke();
    }
}