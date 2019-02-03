using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    [SerializeField] float standingThreshold;

	// Use this for initialization
	void Start () {
		
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


    //public void Lower()
    //{
    //    transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
    //    rib.useGravity = true;
    //    rib.freezeRotation = true;
    //}

    //public void ResetPin()
    //{
    //    if (gameObject)
    //    {
    //        rib.freezeRotation = false;
    //        rib.useGravity = true;
    //    }
    //}
}
