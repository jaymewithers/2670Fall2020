using UnityEngine;

public class IfStatements : MonoBehaviour
{
    public bool canRun;
    public string password;
    public int number;
    private void Start()
    {
        if (canRun)
        {
            Debug.Log("Running");
        }
    }


    private void Update()
    {
        if (!canRun)
        {
            Debug.Log("Running");
        }

        Debug.Log(password == "OU812" ? "Correct" : "Incorrect");

        Debug.Log(number >= 7 ? "Greater than 7" : "Less than 7");
    }
}