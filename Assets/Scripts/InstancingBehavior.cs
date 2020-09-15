using UnityEngine;

public class InstancingBehavior : MonoBehaviour
{
    public Instancer prefabObj;

    public void InstanceAtTransform()
    {
        Instantiate(prefabObj, transform);
    }
}