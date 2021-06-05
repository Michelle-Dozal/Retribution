using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth,attackDamage;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "")
        {
            takeDamage(attackDamage);
        }
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        // set hurt animation here
        if (currentHealth <= 0)
        {
            enemyDies();
        }
    }

    private void enemyDies()
    {
        Debug.Log("Enemy destroyed.");
        //put die animation here
        //@Raymond v whatever the states will be called
      //  Animator.SetBool("IsDead", true);
      GetComponent<Collider2D>().enabled = false; 
      this.enabled = false;
      Destroy(gameObject);
    }
/*
    void OnCollisionEnter(Collision collision)
    {

        Enemy_AI other = collision.gameObject.GetComponent<Enemy_AI>();
        if(other){
            Destroy(gameObject);
        }
    }
*/
}