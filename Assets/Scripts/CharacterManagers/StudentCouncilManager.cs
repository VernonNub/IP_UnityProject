using System;
using System.Collections;
using System.Collections.Generic;
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
        Scolding, 
        Idle
    }

    //Add your
    public Dictionary<Vector3, string> aiAction = new Dictionary<Vector3, string>()
    {
        //Keep your Y axis 0 for everything
        {new Vector3(4.77f,0f,-14.52f), "Talking"},
        {new Vector3(10.23f,0f,-5.67f), "Scolding"},
        {new Vector3(0f,0f,0f), "Idle"}
    };

    //Current AI State
    public AiStates aiStates = AiStates.Moving;

    void Update()
    {
        CheckState();

        ActionFinished();

        UpdateGameManager();

        //Checks changeState flag --> changes state if its true (Meaning AI can change action)
        if (changeState)
        {
            ChangeState();
        }
    }

    private void UpdateGameManager()
    {
        GameManager.instance.NPC1Happiness = happiness;
        GameManager.instance.NPC1Relationship = relationship;
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
                aiAnimator.SetTrigger("Talk");
                changeState = false;
                break;
            case AiStates.Scolding:
                aiAnimator.SetTrigger("Scold");
                changeState = false;
                break;
            case AiStates.Idle:
                aiAnimator.SetTrigger("Idle");
                changeState = false;
                break;
        }
    }
}
