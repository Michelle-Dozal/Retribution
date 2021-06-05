using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    //This gets the position of what we want to follow
    public Transform follow;
    public BoxCollider2D bounds;

    private float xMax, xMin, yMax, yMin;
    private float xCam, yCam;
    private float camSize;
    private float camRatio;

    private Camera mainCam;

    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;
    private void Awake()
    {
        //gets the maxs
        xMax = bounds.bounds.max.x;
        yMax = bounds.bounds.max.y;

        //get the mins
        xMin = bounds.bounds.min.x;
        yMin = bounds.bounds.min.y;

        //This deals with getting a handle on the camera
        //as well as getting it's dimetions
        mainCam = GetComponent<Camera>();
        camSize = mainCam.orthographicSize;
        camRatio = (xMax + camSize) / 2.0f;
    }
    void FixedUpdate()
    {
        xCam = Mathf.Clamp(follow.transform.position.x, xMin + camRatio, xMax - camRatio);
        yCam = Mathf.Clamp(follow.transform.position.y, yMin + camSize, yMax - camSize);
        //This line smooths out the following camera
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(xCam, yCam, this.transform.position.z), smoothSpeed);
        this.transform.position = smoothPos;
    }
}
