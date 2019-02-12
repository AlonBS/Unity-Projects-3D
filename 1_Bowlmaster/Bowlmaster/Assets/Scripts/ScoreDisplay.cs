using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {


    [SerializeField] Text[] rollsText, framesText;

	// Use this for initialization
	void Start () {

        foreach (Text text in rollsText)
        {
            text.text = "";
        }

        foreach (Text text in framesText)
        {
            text.text = "";
        }

        rollsText[0].text = "X";
        framesText[0].text = "043";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void UpdateScore(List<int> rolls, List<int> framesScores)
    {
        if ( (rolls.Count > rollsText.Length) ||
             (framesScores.Count > framesText.Length) )
        {
            throw new UnityException("Too many rolls or frames where passed to Score Display");
        }

        for (int i = 0; i < rolls.Count; ++i)
        {
            rollsText[i].text = rolls[i].ToString();
        }

        for (int i = 0; i < framesScores.Count; ++i)
        {
            framesText[i].text = framesScores[i].ToString();
        }


    }
}
