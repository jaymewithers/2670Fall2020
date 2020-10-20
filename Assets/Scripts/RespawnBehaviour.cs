using System.Collections;
using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{
    public Vector3Data spawnPoint;
    public FloatData health;

    private void Update()
    {
        if (health.value <= 0)
        {
            StartCoroutine(DeathAndRespawn(gameObject));
        }
    }

    private IEnumerator DeathAndRespawn(GameObject obj)
    {
        obj.SetActive(false);
    
        if (obj.name != "Player") yield break;
        obj.transform.position = spawnPoint.value;
        health.value = 1f;
        obj.SetActive(true);
    }
}