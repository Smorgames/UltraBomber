using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageMove : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss>().isRageStage = true;
        animator.GetComponent<Boss>().isResisting = false;
    }
}
