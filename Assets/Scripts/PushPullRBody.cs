using UnityEngine;

public class PushPullRBody : MonoBehaviour
{
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = player.transform;
    }
}