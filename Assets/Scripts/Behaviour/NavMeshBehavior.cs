using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshBehavior : MonoBehaviour
{
    private readonly NavMeshAgent agent;
    public float speed;
    public Transform player;

    public NavMeshBehavior(NavMeshAgent agent)
    {
        this.agent = agent;
    }

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