using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        for (int i = 1; i < rolls.Count && frameList.Count < 10; i+=2)
        {
            if (rolls[i - 1] + rolls[i] < 10)  // Open frame
            {
                frameList.Add(rolls[i - 1] + rolls[i]);
            }

            if (i + 1 >= rolls.Count) break;

            else if (rolls[i - 1] == 10) // Strike
            {
                frameList.Add(10 + rolls[i] + rolls[i + 1]);
                --i;
            }

            else if (rolls[i - 1] + rolls[i] == 10) // Spare
            {
                    frameList.Add(10 + rolls[i + 1]);
            }

        }

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
