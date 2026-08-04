using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assemblies;

public class AIManager : MonoBehaviour
{
    public List<Transform> navigationPoints = new List<Transform>();
    [SerializeField] NavMeshAgent aiAgent;
    [SerializeField] Transform targetDestination;
    public bool changeState = true;

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
        if(aiAgent.remainingDistance == aiAgent.stoppingDistance)
        {
            changeState = true;
        }
    }
}
