using UnityEngine;

public class MoveLocator : MonoBehaviour
{
    private Camera cam;
    public Transform pointObj;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            pointObj.position = hit.point;
        }
    }
}