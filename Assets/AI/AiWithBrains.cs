using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AiWithBrains : MonoBehaviour
{
    private NavMeshAgent agent;
    private int i = 0;

    public List<AiBrainBase> brainUpgrades;
    
    public AiBrainBase aiBrain;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        aiBrain.Navigate(agent);
    }

    private void OnTriggerEnter(Collider other)
    {
        aiBrain = brainUpgrades[i];

        if (i < brainUpgrades.Count)
        {
            i++;
        }
    }
}
