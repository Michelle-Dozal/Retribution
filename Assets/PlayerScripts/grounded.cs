/*
 * Description - This file handles anything relating to ground detection and how many jumps
 * the player might have for later in the game.
 * 
 * Author - Raymond Booth
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{
    //gives us access to the player
    GameObject Player;
    //To store the starting amount of jumps
    private int startJumps;
    private short count;
    void Start()
    {
        //goes to the parent object of the collition box which would be the player
        Player = gameObject.transform.parent.gameObject;
        //gets the amount of jumps from the parent
        startJumps = Player.GetComponent<move2D>().jumpNum;
        count = 0;
    }

    //This gets called whenever collition first enters
    //Resets the amount of jumps and turns isGrounded to true
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("bottom collision detected");
        Player.GetComponent<move2D>().jumpNum = startJumps;
        Player.GetComponent<move2D>().isGrounded = true;
        count++;
    }
    //This gets called when the collition is left
    //Resets isGrounded to false
    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("left collision");
        count--;
        if(count == 0)
            Player.GetComponent<move2D>().isGrounded = false;
    }

}