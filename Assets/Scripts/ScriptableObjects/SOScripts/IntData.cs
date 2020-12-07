using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;
    public UnityEvent maxValueEvent;

    public void UpdateIntPlusOne(int maxValue)
    {
        value++;
        if (value == maxValue)
        {
            maxValueEvent.Invoke();
        }
    }
}