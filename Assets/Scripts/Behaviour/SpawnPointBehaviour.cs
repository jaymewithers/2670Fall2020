using UnityEngine;

public class SpawnPointBehaviour : MonoBehaviour
{
    public Vector3Data vData;

    private void OnTriggerEnter(Collider other)
    {
        vData.SetValueFromVector3(transform.position);
    }
}