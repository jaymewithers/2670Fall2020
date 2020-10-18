using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBehaviour : MonoBehaviour
{
    private Image imageObj;
    public FloatData valueObj;

    private void Start()
    {
        imageObj = GetComponent<Image>();
    }

    public void Update()
    {
        imageObj.fillAmount = valueObj.value;
    }
}