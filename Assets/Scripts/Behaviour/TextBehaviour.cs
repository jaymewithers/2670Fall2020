using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextBehaviour : MonoBehaviour
{
    private Text textObj;
    public FloatData dataObj;
    public StringListData value;

    private void Start()
    {
        textObj = GetComponent<Text>();
    }

    private void Update()
    {
        textObj.text = dataObj.value.ToString(CultureInfo.CurrentCulture);
    }
    
    public void TextToStringData()
    {
        textObj.text = value.ToString();
    }
}