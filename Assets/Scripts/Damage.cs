using UnityEngine;

public class Damage : MonoBehaviour
{
    public FloatData health;

    private void OnTriggerEnter(Collider other)
    {
        health.value--;
    }
}