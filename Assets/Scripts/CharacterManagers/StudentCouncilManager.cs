using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class StudentCouncilManager : AIManager
{
    //AI States to change between (The action that your AI performs)
    public enum AiStates
    {
        Vaping,
        Talking,
        Moving,
    }

    //Current AI State
    public AiStates aiStates = AiStates.Moving;

    void Update()
    {
        CheckState();

        //Checks changeState flag --> changes state if its true (Meaning AI can change action)
        if (changeState)
        {
            ChangeState();
        }
    }

    private void ChangeState()
    {
        Vector3 position = gameObject.transform.position;
        position.y = 0;

        if (!actionPerformed && aiAction.ContainsKey(position))
        {
            RunAiAction((AiStates)Enum.Parse(typeof(AiStates), aiAction[position]));
        }
        else
        {
            RunAiAction(AiStates.Moving);
        }
    }

    //Runs the actions
    private void RunAiAction(AiStates action)
    {
        aiStates = action;
        //Runs logic based on current state
        switch (aiStates)
        {
            //Moving Logic (Runs when AiState is moving)
            case AiStates.Moving:
                actionPerformed = false;
                changeState = false;
                MoveToDestination();
                break;
            case AiStates.Talking:
                changeState = false;
                break;

        }
    }

    //Add this to your animation event ("Turn flag on when your animation is done")
    public void ActionFinished()
    {
        actionPerformed = true;
    }
}
