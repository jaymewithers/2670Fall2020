using UnityEngine;
using UnityEngine.UI;

public class TextDisplayBehaviour : MonoBehaviour
{
    public Text textObj;
    public StringData value;

    public void TextToStringData()
    {
        textObj.text = value.value;
    }
}