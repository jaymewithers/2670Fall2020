using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public ApplyForce script;

    private void Start()
    {
        script = GetComponent<ApplyForce>();
        script.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        script.enabled = true;
    }
}