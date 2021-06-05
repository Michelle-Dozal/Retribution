using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class health : MonoBehaviour
{
    public int currHealth = 0;
    public int maxHealth = 100;
    public int healthforsave; 
    public HealthBar healthBar;
    public GameManager DeathScreen;
    public GameObject Screen;
    public AudioSource song;
    
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    
    }

    // Update is called once per frame
    void Update()
    {   
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     DamagePlayer(10);
        // }
        healthforsave = currHealth;
    }
    public void DamagePlayer(int damage){
        currHealth -= damage;
        //healthBar.SetHealth(currHealth);
        
        if(currHealth <= 0){
            DeathScreen.GameOver();
        }
        healthBar.SetHealth(currHealth);
    }


    public void HealPlayer(int heal){
        currHealth += heal;
       
        if(currHealth >= maxHealth){
            currHealth = maxHealth;
        }
        healthBar.SetHealth(currHealth);
    }


     public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }
    
    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();
        currHealth = data.health;
        healthBar.SetHealth(currHealth);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        //Screen.SetActive(false);
        ClosePanel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player was hit");
        if (collision.otherCollider.name == "hitBox")
        {   
            DamagePlayer(10);
        }
    }

    public void ClosePanel(){
        Screen.SetActive(!Screen.activeSelf);
    }


}
