using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    [SerializeField] Ball ball;

    private Vector3 offset;
    private const int CAMERA_STOP_MOV_Z_POS = 16;

	// Use this for initialization
	void Start () {

        offset = ball.transform.position - this.transform.position;


    }
	
	// Update is called once per frame
	void Update () {

        if (ball.transform.position.z <= CAMERA_STOP_MOV_Z_POS)
        {
            transform.position = ball.transform.position - offset;

        }
		
	}
}
