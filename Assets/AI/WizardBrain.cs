using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class WizardBrain : AiBrainBase
{
    public override void Navigate(NavMeshAgent agent)
    {
        base.Navigate(agent);
        // do what wizards do
    }
}
