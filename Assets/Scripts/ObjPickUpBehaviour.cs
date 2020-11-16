using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjPickUpBehaviour : MonoBehaviour
{
    private Rigidbody rBody;
    private bool canPickUp;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        canPickUp = Input.GetKeyDown(KeyCode.Z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (canPickUp)
        {
            transform.parent = other.transform;
            rBody.isKinematic = true;
            rBody.useGravity = false;
        }
        else
        {
            transform.parent = null;
            rBody.isKinematic = false;
        }
    }
}