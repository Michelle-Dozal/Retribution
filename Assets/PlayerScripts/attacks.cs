using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacks : MonoBehaviour
{

    private BoxCollider2D weaponBox;
    public float attackTime = 0f;
    public float attackTimeMax = 1f;
    private MeshRenderer mesh;
    public move2D player;
    public int attackDamage = 50;
    
    // Start is called before the first frame update
    private void Awake()
    {
        weaponBox = gameObject.GetComponent<BoxCollider2D>();
        weaponBox.enabled = false;
        weaponBox.isTrigger = true;
        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer();
        if (Input.GetKeyDown(KeyCode.R))
        {
            attackStart();
        }
        /*
        if (player.facingRight)
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(0.097f, -0.057f, -0.8156823f);
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position = new Vector3(-0.097f, -0.057f, -0.8156823f);
            }
        }*/


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something entered attack");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Something left attack");
    }
    private void attackStart()
    {
        Debug.Log("melee attack on");
        weaponBox.enabled = true;
        mesh.enabled = true;
        


/* mithra attack damage
        void OnCollisionEnter(Collision collision)
        {
            if (Rigidbody2D.) {
                
            }
        } 
        end mithra attack damage */
        
    }
    private void timer()
    {
        if (weaponBox.enabled)
        {
            //increments the time
            attackTime += Time.deltaTime;
            //Does the resetting
            if (attackTime >= attackTimeMax)
            {
                Debug.Log("melee attack off");
                attackTime = 0;
                weaponBox.enabled = false;
                mesh.enabled = false;
            }
        }
    }
}
