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

    //Add your states here
    // the int is just the storyprogress scene, refer to gamemanager's variable for story detail. Same int
    public Dictionary<int, Dictionary<Vector3, string>> aiAction = new Dictionary<int, Dictionary<Vector3, string>>()
    {
        {0, new Dictionary<Vector3, string>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f), "Talking"},
            } 
        },
    };

    //Current AI State
    public AiStates aiStates = AiStates.Moving;

    void Update()
    {
        CheckState();

        ActionFinished();

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

        if (aiAction.ContainsKey(GameManager.instance.storyProgress))
        {
            if (!actionPerformed && aiAction[GameManager.instance.storyProgress].ContainsKey(position))
            {
                RunAiAction((AiStates)Enum.Parse(typeof(AiStates), aiAction[GameManager.instance.storyProgress][position]));
            }
            else
            {
                RunAiAction(AiStates.Moving);
            }
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
