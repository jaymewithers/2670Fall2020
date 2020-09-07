using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    public float speed;
    public Transform player;
    private void Start()
    {
        GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }


    private void Update()
    {
        agent.destination = player.position;
    }
}