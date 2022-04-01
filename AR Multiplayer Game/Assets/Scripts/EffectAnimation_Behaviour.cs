using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimation_Behaviour : StateMachineBehaviour
{
    public AnimationClip effectAnimation;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        string ActionString = effectAnimation.ToString().Substring(0, effectAnimation.ToString().IndexOf(" "));

        animator.transform.GetChild(0).GetComponent<Animator>().Play(ActionString
            );
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
