using UnityEngine;

public class Lerping : MonoBehaviour
{
    public Vector3 vOne, vTwo;
    public float value;

    private void Update()
    {
        var direction = Vector3.Lerp(vOne, vTwo, value);
        value += .1f * Time.deltaTime;
        transform.position = direction;
    }
}