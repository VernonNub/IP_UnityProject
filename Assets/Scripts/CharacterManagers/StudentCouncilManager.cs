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
        if(changeState) 
        {
            RunAiAction(AiStates.Moving);
        }
    }

    //Runs the actions
    private void RunAiAction(AiStates action)
    {
        //Runs logic based on current state
        switch(aiStates)
        {
            //Moving Logic (Runs when AiState is moving)
            case AiStates.Moving:
                changeState = false;
                MoveToDestination();
                break;
        }
    }
}
