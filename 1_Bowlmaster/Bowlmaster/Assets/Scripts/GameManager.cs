using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> bowls;
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {

        bowls = new List<int>();
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
        
        scoreDisplay = FindObjectOfType<ScoreDisplay>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bowl(int pinFall)
    {
        bowls.Add(pinFall);
        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSetter.PerformAction(nextAction);

        try
        {
            scoreDisplay.UpdateScore(bowls, ScoreMaster.ScoreFrames(bowls));
        }
        catch (UnityException e) {
            Debug.Log("Unable to upate score.");
            Debug.Log(e.ToString());
        }
        
        ball.Reset();
    }
}
