using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextBehaviour : MonoBehaviour
{
    private Text textObj;
    public FloatData dataObj;

    private void Start()
    {
        textObj = GetComponent<Text>();
    }


    private void Update()
    {
        textObj.text = dataObj.value.ToString(CultureInfo.CurrentCulture);
    }
}