using UnityEngine;

public class AddScore : MonoBehaviour
{
    public IntData scoreData;

    private void OnTriggerEnter(Collider other)
    {
        scoreData.value++;
    }
}