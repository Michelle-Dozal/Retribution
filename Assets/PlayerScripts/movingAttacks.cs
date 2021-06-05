/*
 * Description - This file handles the attacks the player can do
 * 
 * Author - Raymond Booth
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAttacks : MonoBehaviour
{

    private Collider2D ballCol;
    private float attackTime = 0f;
    public float attackTimeMax;
    public Transform playerPos;
    public move2D player;
    public float move;
    public string button;
    private float animationDir = 0.5f;
    public Animator animator;
    public AudioClip pickSound;
    private void Awake()
    {
        ballCol = gameObject.GetComponent<Collider2D>();
        ballCol.enabled = false;
        ballCol.isTrigger = true;
        attackTimeMax = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button) && !ballCol.enabled && player.isGrounded)
        {
            attackStart();
        }
        timer();
        animator.SetBool("attack", ballCol.enabled);
        player.attackActivate = ballCol.enabled;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Debug.Log("Something entered attack");
        if(collision.name != "Player")
        {
            Debug.Log("fireball attack off");
            attackTime = 0;
            ballCol.enabled = false;
        }*/
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Something left attack");
    }
    private void attackStart()
    {
        //makes sure the attack is going the direction the player was
        //facing when the attack comes out
        if (player.facingRight)
        {
            animationDir = Mathf.Abs(animationDir);
            if (move < 0)
            {
                move *= -1;
            }
        }
        else
        {
            animationDir = Mathf.Abs(animationDir) * -1;
            if (move > 0)
            {
                move *= -1;
            }
        }
        Debug.Log("melee attack on");
        ballCol.enabled = true;
        transform.position = new Vector3(playerPos.position.x + animationDir, playerPos.position.y, playerPos.position.z);
        AudioSource.PlayClipAtPoint(pickSound,transform.position);
    //    transform.position = playerPos.position;
    }
    private void timer()
    {
        if (ballCol.enabled)
        {
            transform.Translate(new Vector3(move, 0f));
            //increments the time
            attackTime += Time.deltaTime;
            //Does the resetting
            if (attackTime >= attackTimeMax)
            {
                Debug.Log("fireball attack off");
                attackTime = 0;
                ballCol.enabled = false;
            }
        }
    }
}
