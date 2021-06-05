using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndofGame : MonoBehaviour
{   public GameObject EndingScreen;
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
            Debug.Log("Collision With EndFire");

            EndingPanel();
        }
    }

    public void EndingPanel(){
        EndingScreen.SetActive(true);
        
    }
}
