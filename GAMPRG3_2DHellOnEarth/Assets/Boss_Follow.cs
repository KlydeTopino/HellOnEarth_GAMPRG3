using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Follow : StateMachineBehaviour
{
    public Transform player;

    public Rigidbody2D rb;

    public float moveSpeed = 2.5f;
    public float attackRange = 3f;

    public Boss boss;

    public PlayerHealth playerHealthScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        playerHealthScript = player.GetComponent<PlayerHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector3 temp = Vector3.MoveTowards(rb.position, player.position, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(temp);

        if (playerHealthScript.isDead == false && Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
