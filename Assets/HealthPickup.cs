using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthPickup : MonoBehaviour
{   
    public AudioClip pickSound;
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
            AudioSource.PlayClipAtPoint(pickSound,transform.position);
            Debug.Log("Collision With HealthBoost");
            Object.FindObjectOfType<health>().HealPlayer(50); //Add health
            Destroy(gameObject); //destroy after boost
        }
    }
}
