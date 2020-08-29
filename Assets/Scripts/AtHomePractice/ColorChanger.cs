using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer obj;
    
    private void Start()
    {
        obj = GetComponent<Renderer>();
        obj.material.color = Color.red;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            obj.material.color = Color.green;
        }

        if (Input.GetKey(KeyCode.Y))
        {
            obj.material.color = Color.yellow;
        }
    }
}