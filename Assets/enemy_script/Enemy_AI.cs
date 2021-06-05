using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_AI : MonoBehaviour
{
    [Header("Pathfinding")]  /* This will show in unity the heading name*/
    public Transform target;                /* A transform target */
    public float activateDistance = 50f;    /* activation distance */
    public float pathUpdateSeconds = 0.5f;  /* updating the astar algorithm */

    [Header("Physics")]
    public float speed = 200f;                  /* speed of the character */
    public float nextWaypointDistance = 3f;     /* This is how far the enemy needs to be in order to start moving towards the next way point */
    public float jumpNodeHeightRequire = 0.8f;  /* how virtecal that the next node need in order for the character to jump */
    public float jumpModifier = 0.3f;           /* how high and how powerful the enemy can jump*/
    public float jumpCheck = 0.1f;  /* more for the collider */

    [Header("Custom Behavior")]
    public bool followEnable = true;   /* can use this for when the enemy dies then they will stop following */
    public bool jumpEnable = true;     /* enable when to jump */
    public bool directionSwitchEnable = true;  /* this is for when we want to see the dirction change */

    private Path path;
    private int currentWaypoint = 0;
    bool checkGround = false;
    Seeker seeker;
    Rigidbody2D rd;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rd = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds); /* This will repeat the same script over and over again */
    }

    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnable)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnable && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rd.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        /* check if path is null */
        if (path == null)
        {
            return;
        }

        /* reached end of the path */
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        /* checking if we are colliding to anything */
        //checkGround = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheck);

        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheck);
        checkGround = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        /* Directions calculation */
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rd.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;  /*creating the force*/

        /* jump added */
        if (jumpEnable && checkGround)
        {
            if (direction.y > jumpNodeHeightRequire)
            {
                rd.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        /*Movement added with force*/
        rd.AddForce(force);

        /*Next Waypoint */
        float distance = Vector2.Distance(rd.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        /* Direction graphics handling */
        if (directionSwitchEnable)
        {
            if (rd.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void OnPathComplete(Path p1)
    {
        if (!p1.error)
        {
            path = p1;
            currentWaypoint = 0;
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance; /* tring to see if we are inside the activate disance */
    }
}
