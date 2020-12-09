using UnityEngine;

public class DataStorageBehaviour : MonoBehaviour
{
    public DataStorage dataStorageObj;
    public FloatData floatDataObj;
    public GameAction gameActionObj;

    private void Start()
    {
        //hard coding instead of events
        floatDataObj.value = 10f;
        dataStorageObj.GetListData();
        gameActionObj.Raise();
    }

    private void OnApplicationQuit()
    {
        dataStorageObj.SetData(floatDataObj);
        dataStorageObj.SetListData();
    }
}