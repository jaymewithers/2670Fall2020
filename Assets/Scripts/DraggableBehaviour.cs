using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBehaviour : MonoBehaviour
{
    private Vector3 offsetPosition, newPosition; 
    private bool canDrag { get; set; }
    private Camera cam;
    
    public bool draggable { get; set; }
    public UnityEvent onDrag, onUp;

    private void Start()
    {
        cam = Camera.main;
        draggable = true;
    }

    private IEnumerator OnMouseDown()
    {
        onDrag.Invoke();
        offsetPosition = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForFixedUpdate();
        canDrag = true;
        while (canDrag)
        {
            yield return new WaitForFixedUpdate();
            newPosition = cam.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        canDrag = false;
        if (draggable)
        {
            onUp.Invoke();
        }
    }
}