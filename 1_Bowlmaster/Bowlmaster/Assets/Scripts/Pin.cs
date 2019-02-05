using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    [SerializeField] float standingThreshold;
    [SerializeField] float distanceToRaise = 0.4f;


    private Rigidbody rigidBody;

    // Use this for initialization
    void Start () {

        rigidBody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public bool IsStanding()
    {
        float tiltInX = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.x, 0));
        float tiltInZ = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, 0));


        return (tiltInX < standingThreshold && tiltInZ < standingThreshold);
    }


    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            transform.position += new Vector3(0f, distanceToRaise, 0f);
            rigidBody.useGravity = false;
        }
    }


    public void Lower()
    {
        transform.position -= new Vector3(0f, distanceToRaise, 0f);
        rigidBody.useGravity = true;
    }




}
