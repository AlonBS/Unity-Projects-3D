using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBox : MonoBehaviour {

    private PinSetter pinSetter;

	// Use this for initialization
	void Start () {

        pinSetter = FindObjectOfType<PinSetter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Ball>())
    //    {
    //        pinSetter.BallOutOfPlay();
    //    }
    //}
}
