using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> bowls;
    private PinSetter pinSetter;
    private Ball ball;

	// Use this for initialization
	void Start () {

        bowls = new List<int>();
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bowl(int pinFall)
    {
        bowls.Add(pinFall);
        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSetter.PerformAction(nextAction);

        ball.Reset();
    }
}
