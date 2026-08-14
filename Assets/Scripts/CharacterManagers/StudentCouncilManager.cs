using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class StudentCouncilManager : AIManager
{
    //AI States to change between (The action that your AI performs)
    public enum AiStates
    {
        Talking,
        Moving,
        Scold,
        Idle,
    }

    //Add your states here
    // the int is just the storyprogress scene, refer to gamemanager's variable for story detail. Same int
    public Dictionary<int, Dictionary<Vector3, string>> aiAction = new Dictionary<int, Dictionary<Vector3, string>>()
    {

        /* doesnt work rn
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

        {3, new Dictionary<Vector3, string>() 
            {
                {new Vector3(123.410004f,0f,-24.8999996f), "Thinking"},
                
            }
        },*/
    };

    public Dictionary<int, List<Vector3>> aiMovement = new Dictionary<int, List<Vector3>>()
    {
        {0, new List<Vector3>()
            {
                //Example
                {new Vector3(154.136276f,49.2101479f,87.9918365f)},
                {new Vector3(153.75f,49.2101479f,92.4100037f)},
                {new Vector3(166f,49.2101479f,90.4000015f)}
            }
        },

        {1, new List<Vector3>()
            {
                //Example
                {new Vector3(154.136276f,49.2101479f,87.9918365f)},
                {new Vector3(157.979996f,49.2101479f,87.5199966f)},
                {new Vector3(166f,49.2101479f,90.4000015f)}
            }
        },

        {2, new List<Vector3>()
            {
                //Example
                {new Vector3(118.099998f,30.1649456f,-40f)},
                {new Vector3(118.099998f,30.1649456f, -13.08f)},
                {new Vector3(113.760002f,30.1649456f,-54.2299995f)}
            }
        },

        {3, new List<Vector3>()
            {
                //Example
                {new Vector3(159.080002f,49.2851105f,80.4599991f)},
                {new Vector3(165.671f,49.2851105f,89.68f)},
            }
        },

        {4, new List<Vector3>()
            {
                //Example
                {new Vector3(159.080002f,49.2851105f,80.4599991f)},
                {new Vector3(165.671f,49.2851105f,89.68f)},
                {new Vector3(159.80999f,49.2851105f,87.4199982f)}
            }
        },

        {5, new List<Vector3>()
            {
                //Example
                {new Vector3(170.649994f,30.1329575f,-29.6399994f)},
                {new Vector3(170.649994f,30.1329575f,-7.3f)},
                {new Vector3(141.64f,30.1329575f,-15f)},
            }
        },

        {6, new List<Vector3>()
            {
                //Example
                {new Vector3(154.136276f,49.2101479f,87.9918365f)},
                {new Vector3(153.75f,49.2101479f,92.4100037f)},
                {new Vector3(166f,49.2101479f,90.4000015f)},
                {new Vector3(160.880005f,49.2851105f,91.6100006f)}
            }
        },

        {7, new List<Vector3>()
            {
                //Example
                {new Vector3(176.080002f,49.2851105f,80.4599991f)},
                {new Vector3(165.671f,49.2851105f,89.68f)},
                {new Vector3(159.809998f,49.2851105f,81.1100006f)}
            }
        },

        {8, new List<Vector3>()
            {
                //Example
                {new Vector3(154.136276f,49.2101479f,87.9918365f)},
                {new Vector3(166f,49.2101479f,90.4000015f)},
                {new Vector3(160.880005f,49.2851105f,91.6100006f)}
            }
        },

        {9, new List<Vector3>()
            {
                //Example
                {new Vector3(154.136276f,49.2101479f,87.9918365f)},
                {new Vector3(150.75f,49.2101479f,92.4100037f)},
                {new Vector3(160.880005f,49.2851105f,91.6100006f)}
            }
        },
    };

    protected Animator aiAnimator;
    protected NavMeshAgent aiAgent;

    void OnEnable()
    {
        aiAnimator = gameObject.GetComponent<Animator>();
        aiAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    //Current AI State
    public AiStates aiStates = AiStates.Moving;

    void Update()
    {
        CheckState();

        ActionFinished();

        //Checks changeState flag --> changes state if its true (Meaning AI can change action)
        if(changeState) 
        {
            GameManager.instance.NPC2Transform = gameObject.transform;

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

        if((GameManager.instance.storyProgress == 2 || GameManager.instance.storyProgress == 5) && GameManager.instance.sceneName != "Canteen")
        {
            destination = stairs;
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

            case AiStates.Scold:
                aiAnimator.SetTrigger("Scold");
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

    public void ResetAnimations()
    {
        aiAnimator.SetBool("IsWalking", false);
    }

    public void ActionFinished()
    {
        if(aiAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            actionPerformed = true;
        }
    }

    protected void CheckState()
    {
        if(aiAgent.remainingDistance == aiAgent.stoppingDistance && !isTalking)
        {
            ResetAnimations();   
            changeState = true;

        }
    }

    public void TalkToPlayer()
    {
        ResetAnimations();
        isTalking = true;

        //Stop Animations, stop movement
        //StopMovement
        aiAgent.SetDestination(gameObject.transform.position);

        //Rotate to face player
        Vector3 rotation = playerManager.gameObject.transform.position;
        gameObject.transform.LookAt(rotation);
    }
}
