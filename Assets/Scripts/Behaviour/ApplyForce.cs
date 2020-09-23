using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    private Rigidbody rBody;
    public float force = 30f;
    //public Vector3Data playerRotation;
    //public GameObject obj;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        var forceDirection = new Vector3(force, 0, 0);
        //obj.transform.Rotate(playerRotation.value);
        rBody.AddRelativeForce(forceDirection);
    }
}