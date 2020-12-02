using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBehaviour : MonoBehaviour
{
    private Image img;
    private float tempValue;
    public FloatData valueObj;

    private void Start()
    {
        img = GetComponent<Image>();
        tempValue = valueObj.value;
    }

    public void UpdateFillAmount()
    {
        StartCoroutine(OnUpdateFillAmount());
    }

    private IEnumerator OnUpdateFillAmount()
    {
        while (tempValue > valueObj.value)
        {
            img.fillAmount = tempValue;
            yield return new WaitForFixedUpdate();
            tempValue -= 0.01f;
        }
        
        tempValue = valueObj.value;
    }

    // public void Update()
    // {
    //     img.fillAmount = valueObj.value;
    // }
}