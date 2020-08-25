using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : StateMachineBehaviour
{
    public float distanceToFollow = 3f;
    public float distanceToAttack = 2f;
    public float speed = 3f;

    private Transform playerPosition;

    public GameObject patrolPoints;
    private Transform[] points = new Transform[5];
    private int nextPoint = 0;

    private string[] rageAttacks = new string[2] { "RageAttack", "RageAttack2"};

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPosition = GameObject.FindWithTag("Player").transform;

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = patrolPoints.transform.GetChild(i);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(playerPosition.position, animator.transform.position) <= distanceToFollow)
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPosition.position, speed * Time.deltaTime); // follow logic

        if (Vector3.Distance(playerPosition.position, animator.transform.position) >= distanceToFollow)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, points[nextPoint].position, speed * Time.deltaTime); // patrol logic
            if (animator.transform.position == points[nextPoint].position)
            {
                if (nextPoint != points.Length - 1)
                    nextPoint++;
                else
                    nextPoint = 0;
            }
        }

        if (Vector3.Distance(playerPosition.position, animator.transform.position) < distanceToAttack && animator.GetComponent<Boss>().isRageStage == false)
            animator.SetTrigger("Attack");
        if (Vector3.Distance(playerPosition.position, animator.transform.position) < distanceToAttack && animator.GetComponent<Boss>().isRageStage == true)
            animator.SetTrigger(rageAttacks[Random.Range(0, 2)]);
    }
}
