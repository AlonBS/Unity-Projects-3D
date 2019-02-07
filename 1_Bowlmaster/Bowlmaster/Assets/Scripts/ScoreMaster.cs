using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {


    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        return frameList;
    }



    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScore = new List<int>();
        int sum = 0;
        foreach (int frameScore in ScoreFrames(rolls))
        {
            sum += frameScore;
            cumulativeScore.Add(sum);
        }


        return cumulativeScore;
    }



}
