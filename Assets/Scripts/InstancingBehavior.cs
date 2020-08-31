using UnityEngine;

public class InstancingBehavior : MonoBehaviour
{
    public GameObject prefab;

    public void InstanceAtTransform()
    {
        Instantiate(prefab, transform);
    }
}