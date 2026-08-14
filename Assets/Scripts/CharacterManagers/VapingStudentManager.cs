using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using Unity.VisualScripting;
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

    //Add your states here
    // the int is just the storyprogress scene, refer to gamemanager's variable for story detail. Same int
    public Dictionary<int, Dictionary<Vector3, string>> aiAction = new Dictionary<int, Dictionary<Vector3, string>>()
    {
        {0, new Dictionary<Vector3, string>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f), "Talking"},
                {new Vector3(176.330002f,0f,80.5199966f), "Thinking"},
                {new Vector3(153.190002f,0f,91.4150009f), "Thinking"},
                {new Vector3(91.5899963f,0f,-28.1800003f), "Idle"},
                {new Vector3(112.809998f,0f,-29.6399994f), "Idle"},
                {new Vector3(165.017136f,0f,81.2013779f), "Idle"},
                {new Vector3(164.679993f ,0f,-7.25f), "Idle"},
                {new Vector3(170.175079f ,0f,81.0924759f), "Thinking"},
                {new Vector3(153.320007f,0f,85.7399979f), "Idle"},
                {new Vector3(165.029999f,0f,86.7200012f), "Thinking"}

            }
        },
    };

    public Dictionary<int, List<Vector3>> aiMovement = new Dictionary<int, List<Vector3>>()
    {
        {0, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {1, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {2, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {3, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {4, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {5, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {6, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {7, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {8, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
            }
        },

        {9, new List<Vector3>()
            {
                //Example
                {new Vector3(4.77f,0f,-14.52f)},
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
        if(changeState) 
        {
            GameManager.instance.NPC1Transform = gameObject.transform;

            ChangeState();
        }
    }

    private void ChangeState()
    {
        Vector3 position = gameObject.transform.position;
        position.y = 0;

        if(!actionPerformed)
        {
            if(aiAction.ContainsKey(GameManager.instance.storyProgress))
            {
                if (aiAction[GameManager.instance.storyProgress].ContainsKey(position))
                {
                    RunAiAction((AiStates)Enum.Parse(typeof(AiStates), aiAction[GameManager.instance.storyProgress][position]));
                }

            }
            else
            {
                actionPerformed = true;
            }
        }
        else
        {
            RunAiAction(AiStates.Moving);
        }
    }

    protected void MoveToDestination()
    {
        Vector3 destination;

        if((GameManager.instance.storyProgress == 2 || GameManager.instance.storyProgress == 5) && GameManager.instance.sceneName == "Canteen")
        {
            destination = stairs.position;
        }
        else
        {
            aiAnimator.SetBool("IsWalking", true);
            destination = aiMovement[GameManager.instance.storyProgress][UnityEngine.Random.Range(0, aiMovement[GameManager.instance.storyProgress].Count)];
        }

        if(destination != targetDestination)
        {
            targetDestination = destination;
            aiAgent.SetDestination(targetDestination);
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
