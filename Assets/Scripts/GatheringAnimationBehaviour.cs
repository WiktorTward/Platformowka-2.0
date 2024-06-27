using UnityEngine;

public class GatheringAnimationBehaviour : StateMachineBehaviour
{
    public delegate void AnimationEventHandler();

    public event AnimationEventHandler OnGatheringStart;
    public event AnimationEventHandler OnGatheringEnd;

    // This method is called when the Animator first transitions into the state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Invoke event when Gathering animation starts
        OnGatheringStart?.Invoke();
    }

    // This method is called when the Animator exits the state.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Invoke event when Gathering animation ends
        OnGatheringEnd?.Invoke();
    }
}
