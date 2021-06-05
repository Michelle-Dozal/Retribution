using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deathbox : MonoBehaviour
{    GameManager DScreen;
        
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "mithra"){
            Debug.Log("Collision With DeathBox");
            //Destroy (col.gameObject);
            Object.FindObjectOfType<GameManager>().GameOver(); //Gameoverscreen
        }
    }
}
