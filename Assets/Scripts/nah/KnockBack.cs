using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public ApplyForceVector script;

    private void Start()
    {
        script = GetComponent<ApplyForceVector>();
        script.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        script.enabled = true;
    }
}