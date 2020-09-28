using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, onEnable;

    private void Start()
    {
        startEvent.Invoke();
    }

    private void OnEnable()
    {
        onEnable.Invoke();
    }
}