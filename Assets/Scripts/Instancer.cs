using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;

    // make a method to call the instance method. maybe same script or a new one
    
    public void Instance()
    {
        var location = transform.position;
        var rotationDirection = new Vector3(0f, 45f,0f);
        Instantiate(prefab, location, Quaternion.Euler(rotationDirection));
    }
}