using UnityEngine;
using UnityEngine.Events;

public class AnimStates : StateMachineBehaviour
{
    public UnityEvent stateEnterEvent, stateExitEvent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateEnterEvent.Invoke();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateExitEvent.Invoke();
    }
}
