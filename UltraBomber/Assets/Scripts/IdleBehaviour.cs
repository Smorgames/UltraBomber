using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    public float distanseToMove = 2f;

    private Transform playerPosition;

    private EnemyAudio enemyAudio;
    private AudioSource audioSource;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPosition = GameObject.FindWithTag("Player").transform;
        enemyAudio = animator.GetComponent<EnemyAudio>();
        audioSource = animator.GetComponent<AudioSource>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(playerPosition.position, animator.transform.position) < distanseToMove)
            animator.SetBool("IsFollowing", true);
        if (!audioSource.isPlaying)
            enemyAudio.PlayGrowlAudio();
    }
}
