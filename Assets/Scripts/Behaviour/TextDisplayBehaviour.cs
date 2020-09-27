using UnityEngine;
using UnityEngine.UI;

public class TextDisplayBehaviour : MonoBehaviour
{
    public Text textObj;

    private void Start()
    {
        textObj.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        textObj.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        textObj.enabled = false;
    }
}
