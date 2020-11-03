using UnityEngine;

public class CarryBehaviour : MonoBehaviour
{
    public bool canCarry;
    public Transform obj, player;
    public float offset = 1.5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "MovableObject") return;
        canCarry = true;
    }
    
    private void Update()
    {
        if (canCarry && Input.GetKeyDown(KeyCode.Z))
        {
            obj.position = player.position * offset;
            obj.transform.parent = player.transform;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            obj.transform.parent = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canCarry = false;
    }
}