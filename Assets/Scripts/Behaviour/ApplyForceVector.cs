using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForceVector : MonoBehaviour
{
    private Rigidbody rBody;
    public Vector3 forces;

    public bool canRunOnStart;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        if (canRunOnStart)
        {
            OnApplyForce();
        }
    }

    public void OnApplyForce()
    {
        rBody.AddRelativeForce(forces);
    }
}