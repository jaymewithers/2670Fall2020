using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3Data vData;
    public CharacterMoverFromClass locationData;

    // set the vData from the position value
    
    private void OnTriggerEnter(Collider other)
    {
        vData.value = locationData.currentSpawnPoint.value;
        // set the location data of the player to the current spawn point
    }
}