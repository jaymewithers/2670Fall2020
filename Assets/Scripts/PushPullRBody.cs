using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushPullRBody : MonoBehaviour
{
    private Rigidbody rBody;
    public bool canPickup;
    public Transform player;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.Z))
        {
            var transformObj = transform;
            transformObj.parent = player;
            canPickup = false;
        }

        if (!Input.GetKeyUp(KeyCode.Z)) return;
        {
            var transformObj = transform;
            transformObj.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canPickup = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }
}