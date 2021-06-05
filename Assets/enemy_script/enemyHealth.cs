/*
 * Description - This deals with anything relating to the enemy health
 * 
 * Author - Raymond Booth
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public short health;
    private bool inHit;
    public AudioClip pickSound;
    private void Awake()
    {
        //enemy will take 2 hits from player to die
        health = 2;
        inHit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemy dies after getting hit twice
        if (health <= 0)
            Destroy(gameObject);
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "attack" && !inHit)
        {
            inHit = true;
            health--;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //This is needed so the enemy only gets hit once from one attack
        //from the player
        if(collision.name == "attack")
            inHit = false;
    }
}
