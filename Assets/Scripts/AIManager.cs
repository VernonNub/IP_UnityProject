using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assemblies;

public class AIManager : MonoBehaviour
{
    public PlayerManager playerManager;

    [Header("AI Details")]
    protected Vector3 targetDestination;

    public bool changeState = true;

    public bool isTalking = false;
    public bool actionPerformed = false;

    public float happiness = 50f;
    public float relationship = 50f;

    public Vector3 stairs = new Vector3(185.509995f,49.2851105f,84.9970016f);


    public void StopTalkingToPlayer()
    {
        changeState = true;
        isTalking = false;
    }

    
}
