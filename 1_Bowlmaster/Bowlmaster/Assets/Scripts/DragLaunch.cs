using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

    private float LANE_WIDTH = 0.8f; 

    // Use this for initialization
    void Start () {
        ball = GetComponent<Ball>();
		
	}


    public void DragStart()
    {
        dragStart = Input.mousePosition;
        startTime = Time.time;
        // capture
    }

    public void DragEnd()
    {
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        Vector3 distance = dragEnd - dragStart;
        float time = endTime - startTime;

        Vector3 velocity = distance / time;
        // Due to UI events - the swipe upwards is capture on Y coords, where we want to translate them to Z-coords.
        velocity.z = velocity.y; 
        velocity.y = 0;
        //launch ball
        ball.Launch(velocity);
    }


    public void MoveStart(float xNudge)
    {
        if (ball.isBallInPlay())
        {
            return;
        }

        float newXPos = Mathf.Clamp(xNudge + ball.transform.position.x, -LANE_WIDTH/2, LANE_WIDTH/2);
        ball.transform.position = new Vector3(newXPos, ball.transform.position.y, ball.transform.position.z);
    }


	
}
