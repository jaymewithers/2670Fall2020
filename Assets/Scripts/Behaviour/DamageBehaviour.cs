using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    public FloatData health;

    private void OnTriggerEnter(Collider other)
    {
        health.value--;
    }
}