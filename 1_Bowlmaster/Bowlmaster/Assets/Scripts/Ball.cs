using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    private Rigidbody rigidBody;
    private AudioSource audioSource;

    private bool inPlay = false;
    private Vector3 startPos;

	// Use this for initialization
	void Start ()
    {

        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        rigidBody.useGravity = false;

        startPos = transform.position;



    }

    public void Launch(Vector3 velocity)
    {
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity / 100;

        audioSource.Play();

        inPlay = true;
    }

    public bool isBallInPlay()
    {
        return inPlay;
    }

    // Update is called once per frame
    void Update () {

	}

    public void Reset()
    {
        transform.position = startPos;
        rigidBody.velocity = new Vector3(0, 0, 0);
        rigidBody.angularVelocity = new Vector3(0, 0, 0);
        rigidBody.useGravity = false;

        inPlay = false;
    }
}
