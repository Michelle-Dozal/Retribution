/*
 * Description - This file handles the sliding movemnet of the player and anything
 * relating to sliding
 * 
 * Author - Raymond Booth
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{
    public bool isSliding = false;
    private move2D player;
    private Rigidbody2D rb2D;
    private BoxCollider2D regCalli;

    private float slideTime = 0f;
    public float slideTimeMax = 1f;
    public bool getUp = true;//This checks if it's okay to get up from slidding

    private Animator animator;
    public AudioClip pickSound;


    void Awake()
    {
        //gets the box collider from the player
        regCalli = gameObject.GetComponent<BoxCollider2D>();
        //gets the rigid body from the player
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        //gets the movement script off the player
        player = gameObject.GetComponent<move2D>();
        //gets the animator from player
        animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && player.isGrounded)
        {
            sliding();
        }
        timer();
        animator.SetBool("slide", isSliding);
    }
    //This method handles sliding components such as moving the caracter and
    //Helping start the timer for the slide durration
    private void sliding()
    {
        Debug.Log("Sliding");
        regCalli.isTrigger = true;
        isSliding = true;
        //Adds the force impulse to slide the character that maxs out the speed in
        //the directions you are going
        rb2D.AddForce(new Vector2(rb2D.velocity.x * player.maxSpeed, 0f), ForceMode2D.Impulse);
        AudioSource.PlayClipAtPoint(pickSound,transform.position);


    }
    //This deals with timing how long the sliding will orcure so we know
    //when to bring back the proper colltion box and reset everything else
    private void timer()
    {
        if (isSliding)
        {
            //increments the time
            slideTime += Time.deltaTime;
            //Debug.Log("Time: " + slideTime + " max time: " + slideTimeMax);
            //Does the resetting
            if (slideTime >= slideTimeMax && getUp)
            {
                regCalli.isTrigger = false;
                isSliding = false;
                slideTime = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + "");
        if (collision.name != "groundcheck")
            getUp = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("trigger exit");
       // if (collision.name != "groundcheck")
            getUp = true;
    }
}