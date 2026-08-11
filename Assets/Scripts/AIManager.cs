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
    public Dictionary<Vector3, string> aiAction = new Dictionary<Vector3, string>()
    {
        //Keep your Y axis 0 for everything
        {new Vector3(4.77f,0f,-14.52f), "Talking"}
    };
    [SerializeField] NavMeshAgent aiAgent;
    [SerializeField] Transform targetDestination;

    public bool changeState = true;

    public bool isTalking = false;
    public bool actionPerformed = false;

    public float happiness = 50f;
    public float relationship = 50f;

    void OnEnable()
    {
        aiAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    protected void MoveToDestination()
    {
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
            changeState = true;
        }
    }

    public void TalkToPlayer()
    {
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
}
