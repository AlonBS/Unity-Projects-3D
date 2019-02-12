using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public static class ActionMaster {

//    private static int[] bowls = new int[21];
//    private static int bowl = 1;

//    public enum Action {

//        TIDY, RESET, END_TURN, END_GAME

//    }


//    public static Action NextAction(List<int> pinFalls)
//    {
//        ActionMaster actionMaster = new ActionMaster();
//        Action action = ActionMaster.Action.END_GAME;
//        foreach (int pinFall in pinFalls)
//        {
//            action = actionMaster.Bowl(pinFall);
//        }

//        return action;
//    }


//    private Action Bowl (int pins)
//    {
//        if (pins < 0 || pins > 10)
//        {
//            throw new UnityException("Invalid number of pins");
//        }

//        bowls[bowl - 1] = pins;

//        if (bowl == 21)
//        {
//            return Action.END_GAME;
//        }


//        if (bowl >= 19 && pins == 10)
//        {
//            bowl++;
//            return Action.RESET;
//        }
//        else if (bowl == 20)
//        {
//            bowl++;
//            if (bowls[18] == 10 && bowls[19] == 0) {
//                return Action.TIDY;
//            }
//            else if (bowls[18] + bowls[19] == 10)
//            {
//                return Action.RESET;
//            }
//            else if (Bowl21Awarded())
//            {
//                return Action.TIDY;
//            }
//            else
//            {
//                return Action.END_GAME;
//            }
//        }

//        if (pins == 10)
//        {
//            bowl += 2;
//            return Action.END_TURN;
//        }
//        if (bowl % 2 != 0)
//        {
//            if (pins == 10)
//            {
//                bowl += 2;
//                return Action.END_TURN;
//            }
//            else
//            {
//                bowl += 1;
//                return Action.TIDY;
//            }
//        }
//        else if (bowl % 2 == 0)
//        {
//            bowl++;
//            return Action.END_TURN;
//        }


//        throw new UnityException("No action taken");
//    }


//    private  bool AllPinsKnockedDown()
//    {
//        return  (bowls[18] + bowls[19] % 10 == 0);
//    }


//    private  bool Bowl21Awarded()
//    {
//        return (bowls[18] + bowls[19] >= 10);
//    }
//}


public static class ActionMaster
{
    public enum Action { TIDY, RESET, END_TURN, END_GAME, UNDEFINED };

    public static Action NextAction(List<int> rolls)
    {
        Action nextAction = Action.UNDEFINED;

        for (int i = 0; i < rolls.Count; i++)
        { // Step through rolls

            if (i == 20)
            {
                nextAction = Action.END_GAME;
            }
            else if (i >= 18 && rolls[i] == 10)
            { // Handle last-frame special cases
                nextAction = Action.RESET;
            }
            else if (i == 19)
            {
                if (rolls[18] == 10 && rolls[19] == 0)
                {
                    nextAction = Action.TIDY;
                }
                else if (rolls[18] + rolls[19] == 10)
                {
                    nextAction = Action.RESET;
                }
                else if (rolls[18] + rolls[19] >= 10)
                {  // Roll 21 awarded
                    nextAction = Action.TIDY;
                }
                else
                {
                    nextAction = Action.END_GAME;
                }
            }
            else if (i % 2 == 0)
            { // First bowl of frame
                if (rolls[i] == 10)
                {
                    rolls.Insert(i, 0); // Insert virtual 0 after strike
                    nextAction = Action.END_TURN;
                }
                else
                {
                    nextAction = Action.TIDY;
                }
            }
            else
            { // Second bowl of frame
                nextAction = Action.END_TURN;
            }
        }

        return nextAction;
    }
}