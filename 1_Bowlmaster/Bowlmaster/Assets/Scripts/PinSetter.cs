using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    
    [SerializeField] GameObject pinsSet;


    private ActionMaster actionMaster;
    private Animator animator;
    private PinCounter pinCounter;
    

	// Use this for initialization
	void Start () {

       //1ball = FindObjectOfType<Ball>();
        actionMaster = new ActionMaster();

        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();


    }
	
	// Update is called once per frame
	void Update () {
        //numOfStandingPins.text = CountStanding().ToString();
        //if (ballOutOfPlay)
        //{
        //    CheckStandingCount();
        //}

    }

    //void CheckStandingCount()
    //{
    //    int count = CountStanding();
    //    if (lastStandingCount != count)
    //    {
    //        lastStandingCount = count;
    //        lastChangeTime = Time.time;
    //        return;
    //    }

    //    if (Time.time - lastChangeTime >= 3f)
    //    {
    //        PinsHaveSettled();
    //    }

        
    //}

    //void PinsHaveSettled()
    //{
    //    int standingPins = CountStanding();
    //    int pinsFall = lastSettledCount - standingPins;
    //    lastSettledCount = standingPins;

    //    // Take Action
    //    ActionMaster.Action action = actionMaster.Bowl(pinsFall);
    //    TakeAction(action);
        


    //    lastStandingCount = -1;
    //    ballOutOfPlay = false;
    //    numOfStandingPins.color = Color.green;
    //    ball.Reset();
    //}


    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.TIDY)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.RESET || action == ActionMaster.Action.END_TURN)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
    }


    //private int CountStanding()
    //{
    //    int standingPinsCount = 0;
    //    foreach (Pin p in FindObjectsOfType<Pin>())
    //    {
    //        if (p.IsStanding())
    //        {
    //            ++standingPinsCount;
    //        }
    //    }

    //    return standingPinsCount;

    //}


    //public void BallOutOfPlay()
    //{
    //    ballOutOfPlay = true;
    //    numOfStandingPins.color = new Color(1.0f, 0, 0);
    //}

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


    /* Raises only standing pins by  distanceToRaise */
    public void RaisePins()
    {
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (Pin p in pins)
        {
            p.RaiseIfStanding();
        }
    }

    /* Lowers only standing pins by  distanceToRaise */
    public void LowerPins()
    {
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (Pin p in pins)
        {
            p.Lower();
        }
    }


    public void RenewPins()
    {
        GameObject pins = Instantiate(pinsSet, new Vector3(0, 0.5f, 18.29f), Quaternion.identity) as GameObject;
        foreach (Rigidbody rib in pins.GetComponentsInChildren<Rigidbody>())
        {
            rib.freezeRotation = true;
        }
    }

}
