using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    [SerializeField] Text numOfStandingPins;

    private GameManager gameManager;

    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    private bool ballOutOfPlay = false;

    // Use this for initialization
    void Start () {

        gameManager = FindObjectOfType<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
        numOfStandingPins.text = CountStanding().ToString();
        if (ballOutOfPlay)
        {
            CheckStandingCount();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            ballOutOfPlay = true;
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
        int standingPins = CountStanding();
        int pinsFall = lastSettledCount - standingPins;
        lastSettledCount = standingPins;

        // Take Action
        //ActionMaster.Action action = actionMaster.Bowl(pinsFall);
        //TakeAction(action);

        gameManager.Bowl(pinsFall);


        lastStandingCount = -1;
        ballOutOfPlay = false;
        numOfStandingPins.color = Color.green;
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

    public void Reset()
    {
        lastSettledCount = 10;
    }
}
