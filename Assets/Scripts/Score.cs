using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreValue;

    private void Start()
    {
        GetComponent<Text>().text = scoreValue.ToString();
    }
}