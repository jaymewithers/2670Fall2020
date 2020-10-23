using System.Collections;
using UnityEngine;

public class PushAndPull : MonoBehaviour
{
    public bool canPushPull;
    public Transform obj, player;
    public float offset = 1.5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "MovableObject")
        {
            canPushPull = true;
            StartCoroutine(OnTriggerStay(null));
        }
    }

    public IEnumerator OnTriggerStay(Collider other)
    {
        if (canPushPull == true)
        {
            yield return new WaitForFixedUpdate();
            obj.transform.position = player.transform.position * offset;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canPushPull = false;
    }
}