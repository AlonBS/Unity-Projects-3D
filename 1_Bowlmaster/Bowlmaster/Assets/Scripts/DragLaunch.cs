using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

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
	
}
