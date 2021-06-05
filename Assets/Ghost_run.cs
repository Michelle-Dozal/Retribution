using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_run : StateMachineBehaviour
{
    /*
    public float speed = 2.5f;
    public float attackRange = 3f;

    Transform player;
    Rigidbody2D rb2;
    Enemy_AI enemy;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy_AI>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtPlayer();
        //Vector2 target = new Vector2(player.position.x, rb2.position.y);
        //Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
       // rb.MovePosition(newPos);

        //this is for starting to attack at a distance
        if (Vector2.Distance(player.position, rb2.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
    */
 
}
