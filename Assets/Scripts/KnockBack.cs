using UnityEngine;

public class Knockback : MonoBehaviour
{
    public GameObject player, enemy;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = enemy.transform.position * 2;
    }
}