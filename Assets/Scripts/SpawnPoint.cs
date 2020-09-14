using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3Data vData;

    private void OnTriggerEnter(Collider other)
    {
        vData.SetValueFromTransform(transform.position);
    }
}