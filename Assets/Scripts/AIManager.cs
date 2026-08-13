using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assemblies;

public class AIManager : MonoBehaviour
{
    public PlayerManager playerManager;

    [Header("AI Details")]
    public List<Transform> navigationPoints = new List<Transform>();

    [SerializeField] NavMeshAgent aiAgent;
    [SerializeField] Transform targetDestination;

    public bool changeState = true;

    public bool isTalking = false;
    public bool actionPerformed = false;

    public float happiness = 50f;
    public float relationship = 50f;

    protected Animator aiAnimator;

    void OnEnable()
    {
        aiAgent = gameObject.GetComponent<NavMeshAgent>();
        aiAnimator = gameObject.GetComponent<Animator>();
    }

    protected void MoveToDestination()
    {
        aiAnimator.SetBool("IsWalking", true);
        Transform destination = navigationPoints[Random.Range(0, navigationPoints.Count)];

        if(destination != targetDestination)
        {
            targetDestination = destination;
            aiAgent.SetDestination(targetDestination.position);
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

    public void StopTalkingToPlayer()
    {
        changeState = true;
        isTalking = false;
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
}
