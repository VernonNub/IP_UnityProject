using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class VapingStudentManager : AIManager
{
    //AI States to change between (The action that your AI performs)
    public enum AiStates
    {
        Thinking,
        Talking,
        Moving,
        Yelling,
        Idle,
    }

    public Dictionary<int, Dictionary<Vector3, string>> aiAction = new Dictionary<int, Dictionary<Vector3, string>>()
    {
        //int key is the scene just make it same as GameManager storydetails.
        //Keep your Y axis 0 for everything
        {0, new Dictionary<Vector3, string>()
            {
                
            }
        },
    };

    //Current AI State
    public AiStates aiStates = AiStates.Moving;

    void Update()
    {
        CheckState();

        ActionFinished();

        UpdateGameManager();

        //Checks changeState flag --> changes state if its true (Meaning AI can change action)
        if(changeState) 
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

        if (!actionPerformed && aiAction[GameManager.instance.storyProgress].ContainsKey(position))
        {
            RunAiAction((AiStates)Enum.Parse(typeof(AiStates), aiAction[GameManager.instance.storyProgress][position]));
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

            case AiStates.Thinking:
                aiAnimator.SetTrigger("Thinking");
                changeState = false;
                break;

            case AiStates.Yelling:
                aiAnimator.SetTrigger("Yell");
                changeState = false;
                break;

            case AiStates.Talking:
                aiAnimator.SetTrigger("Talk");
                changeState = false;
                break;

            case AiStates.Idle:
                aiAnimator.SetTrigger("Idle");
                changeState = false;
                break;
        }
    }
}
