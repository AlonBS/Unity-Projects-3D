﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    [SerializeField] Text numOfStandingPins;



    public int lastStandingCount = -1;

    private float lastChangeTime;
    private bool ballEnteredBox = false;
    private Ball ball;

	// Use this for initialization
	void Start () {

        ball = FindObjectOfType<Ball>();
		
	}
	
	// Update is called once per frame
	void Update () {
        numOfStandingPins.text = CountStanding().ToString();
        if (ballEnteredBox)
        {
            CheckStandingCount();
        }

    }

    void CheckStandingCount()
    {
        int count = CountStanding();
        if (lastStandingCount != count)
        {
            lastStandingCount = count;
            lastChangeTime = Time.time;
            return;
        }

        if (Time.time - lastChangeTime >= 3f)
        {
            PinsHaveSettled();
        }

        
    }

    void PinsHaveSettled()
    {
        lastStandingCount = -1;
        ballEnteredBox = false;
        numOfStandingPins.color = Color.green;
        ball.Reset();
    }


    private int CountStanding()
    {
        int standingPinsCount = 0;
        foreach (Pin p in FindObjectsOfType<Pin>())
        {
            if (p.IsStanding())
            {
                ++standingPinsCount;
            }
        }

        return standingPinsCount;

    }

  


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            numOfStandingPins.color = new Color(1.0f, 0, 0);
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Pin>())
        {
            Destroy(other.transform.parent.gameObject);
        }
    }


    //public void PinsIdleState()
    //{
    //    // Reset to default value when all pins settled down
    //    Pin pin = GameObject.FindObjectOfType<Pin>();
    //    pin.ResetPin();
    //}

    //public void RenewPins()
    //{
    //    GameObject pins = Instantiate(pinSet, new Vector3(0, distanceToRaise, 1829), Quaternion.identity) as GameObject;
    //    foreach (Rigidbody rib in pins.GetComponentsInChildren<Rigidbody>())
    //    {
    //        rib.freezeRotation = true;
    //    }
    //}

}
