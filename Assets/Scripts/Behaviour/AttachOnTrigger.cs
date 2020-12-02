using UnityEngine;

public class AttachOnTrigger : MonoBehaviour
{
    public string tagString;
    public ID idObj;
    
    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<IDHolder>();
        if (otherID == null) return;

        if (otherID.idObj == idObj)
        {
            transform.parent = other.transform;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = null;
    }
}
