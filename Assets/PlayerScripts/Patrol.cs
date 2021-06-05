using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] movingSpot;  /* array of spots to move  */

    private int randomSpot;

    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, movingSpot.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movingSpot[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position,  movingSpot[randomSpot].position) < 0.2f) { }
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, movingSpot.Length);  //to move a differnt position in the array
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;  /* slow decreasing the wait time */ 
            }
        }
    }
}
