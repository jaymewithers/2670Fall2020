using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class AiBrainBase : ScriptableObject
{
    public float health, speed;
    public GameObject art;

    public virtual void Navigate(NavMeshAgent agent)
    {
        // set destination
        // make agents do anything
    }
}
