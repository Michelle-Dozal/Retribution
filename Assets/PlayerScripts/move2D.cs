/*
 * Description - This file handles the majority of the movement of the player which includes
 * horizontal movement and jumping. This file also tracks the speed of the player as well
 * as which way thay are facing.
 * 
 * Author - Raymond Booth
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2D : MonoBehaviour
{
    public float moveSpeed;//This is the force applies to horizontal movement
    public bool isGrounded;//determins if it's grounded
    public float jumpHeight;//how much force is in a jump
    public int jumpNum;//this is the number of jumps the character has
    private Rigidbody2D rb2D;//Used for getting the rigid body of player
    float horMove;//stores the total movemenet of the player's horizontal movement
    public float maxSpeed;
    public bool facingRight;//This it to help tell which direction the player if facing
    private Animator animator;
    public Vector3 playerScale;
    public AudioClip pickSound;
    public bool attackActivate;
    public bool isSliding;
    public slide slideScript;
    public health health;
// sound check
	AudioSource audioSrc;
	bool isMoving = false;
    // Start is called before the first frame update
    void Awake()
    {
        moveSpeed = 15f;
        isGrounded = false;
        jumpHeight = 5f;
        jumpNum = 1;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        horMove = 0f;
        maxSpeed = 5f;
        facingRight = true;
        animator = gameObject.GetComponent<Animator>();
        attackActivate = false;
        isSliding = false;
        slideScript = gameObject.GetComponent<slide>();
        health = gameObject.GetComponent<health>();
        //sound
        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {

        isSliding = slideScript.isSliding;
        playerScale = transform.localScale;
        jump();

        //gets the input and scales it with the speed we want
        horMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        //This gets the animations to work with the player movement
        animator.SetFloat("speed", Mathf.Abs(rb2D.velocity.x));
        animator.SetBool("ground", isGrounded);
        animator.SetBool("attack", attackActivate);


        //flips the person the right way and if they aren't moving they stay facing the same way
        if (horMove > 0)
        {
            facingRight = true;
            playerScale.x = 1;
        }
        else if(horMove < 0)
        {
            facingRight = false;
            playerScale.x = -1;
        }
        //stops player rotating when attacking
        if(!attackActivate)
            transform.localScale = playerScale;


    }
 
    void FixedUpdate()
    {
        //freezes the player if they are attacking
        if (!attackActivate)
        {
            moveHor(horMove);
        }
        else
        {
            rb2D.velocity = new Vector2(0f, 0f);
        }
        /*
        //This helps with the running sound effect
        if (rb2D.velocity.magnitude != 0 && isGrounded && !isSliding)
            isMoving = true;
        else
            isMoving = false;*/
        
        
    }

    //This deals with horizontal movement
    void moveHor(float dir)
    {
        if (attackActivate && isGrounded)
        {
            //stops the player when attacking
            rb2D.velocity = new Vector2(0f, 0f);
        }
        //This limits the velocity of the player in all directions
        if (rb2D.velocity.magnitude >= maxSpeed)
        {
            rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxSpeed);
        }
        //reduces air drift/mobility
        if (!isGrounded)
        {
            dir /= 1.5f;
        }
        //sound check
        if (isMoving) {
            if (!audioSrc.isPlaying)
                audioSrc.Play ();
        }
        else
            audioSrc.Stop ();
       // AudioSource.PlayClipAtPoint(runsound,transform.position);
        rb2D.AddForce(new Vector2(dir, 0f));
        //Debug.Log("Horizontal speed: " + rb2D.velocity.x);
    }

    //Deals with jumping
    void jump()
    {
        //if jump button pressed it will make the character jump
        if (Input.GetButtonDown("Jump") && jumpNum > 0)
        {
            //This line addes the force to make the player jump
            rb2D.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(pickSound,transform.position);
            jumpNum--;
        }

    }
    //This deals with the player getting damaged by the enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "hitBox")
        {
            health.DamagePlayer(10);
        }
    }

}