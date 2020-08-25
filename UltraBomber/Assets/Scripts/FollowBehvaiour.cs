using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehvaiour : StateMachineBehaviour
{
    private EnemyStats enemyStats;
    private Transform playerPosition;

    public float distanceToAttack = 2f;
    public float distanceToIdle = 3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPosition = GameObject.FindWithTag("Player").transform;
        enemyStats = animator.GetComponent<EnemyStats>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPosition.position, enemyStats.enemySpeed * Time.deltaTime);
        if (Vector3.Distance(playerPosition.position, animator.transform.position) > distanceToIdle)
            animator.SetBool("IsFollowing", false);

        if (Vector3.Distance(playerPosition.position, animator.transform.position) < distanceToAttack)
            animator.SetTrigger("Attack");

        if (animator.transform.position.x - playerPosition.position.x < 0)
            animator.transform.localScale = new Vector3(-1f, 1f, 1f);
        else
            animator.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
