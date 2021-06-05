using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireSave : MonoBehaviour
{   

    public GameObject SavingScreen;
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
            Debug.Log("Collision With Fire");
            transform.position = new Vector3 (20f,-2.96f,0f);
            
            SaveGame(); 
            //Object.Destroy(gameObject, 5.0f);
            
        }
    }

    public void SaveGame(){
        SavingScreen.SetActive(true);
        
    }

    public void ExitSaveGame(){
        SavingScreen.SetActive(false);
       
    }
}
