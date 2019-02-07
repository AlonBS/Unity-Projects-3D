using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionMaster {

    private int[] bowls = new int[21];
    private int bowl = 1;

    public enum Action {

        TIDY, RESET, END_TURN, END_GAME

    }


    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster actionMaster = new ActionMaster();
        Action action = ActionMaster.Action.END_GAME;
        foreach (int pinFall in pinFalls)
        {
            action = actionMaster.Bowl(pinFall);
        }

        return action;
    }


    private Action Bowl (int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid number of pins");
        }

        bowls[bowl - 1] = pins;

        if (bowl == 21)
        {
            return Action.END_GAME;
        }


        if (bowl >= 19 && pins == 10)
        {
            bowl++;
            return Action.RESET;
        }
        else if (bowl == 20)
        {
            bowl++;
            if (bowls[18] == 10 && bowls[19] == 0) {
                return Action.TIDY;
            }
            else if (bowls[18] + bowls[19] == 10)
            {
                return Action.RESET;
            }
            else if (Bowl21Awarded())
            {
                return Action.TIDY;
            }
            else
            {
                return Action.END_GAME;
            }
        }

        if (pins == 10)
        {
            bowl += 2;
            return Action.END_TURN;
        }
        if (bowl % 2 != 0)
        {
            if (pins == 10)
            {
                bowl += 2;
                return Action.END_TURN;
            }
            else
            {
                bowl += 1;
                return Action.TIDY;
            }
        }
        else if (bowl % 2 == 0)
        {
            bowl++;
            return Action.END_TURN;
        }


        throw new UnityException("No action taken");
    }


    private  bool AllPinsKnockedDown()
    {
        return  (bowls[18] + bowls[19] % 10 == 0);
    }


    private  bool Bowl21Awarded()
    {
        return (bowls[18] + bowls[19] >= 10);
    }
}

