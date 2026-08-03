using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Search;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Stats")]
    public float playerHealth;
    public float playerSanity = 100;
    public float playerAddiction = 0;
    public float playerHappiness = 50;

    [Header("RayCast")] 
    [SerializeField] float raycastLength = 3;
    private int mask = (1 << 6);

    [Header("Inventory")]
    public List<string> inventory = new List<string>();

    [Header("Components")]
    private Camera playerCamera;
    private CharacterController cc;
    public GameObject checkPoint;

    [SerializeField] InteractibleManager interactibleManager;

    private void OnEnable()
    {
        playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        cc = gameObject.GetComponent<CharacterController>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        HandleRayCast();
        HandlePlayerSanity();
    }
    
    void OnInteract()
    {
        HandleInteraction();
    }

    private void HandleRayCast()
    {
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, raycastLength, mask))
        {
            interactibleManager = hit.collider.gameObject.GetComponent<InteractibleManager>();
        }
        else
        {
            interactibleManager = null;
        }
    }

    private void HandleInteraction()
    {
        if (interactibleManager != null)
        {
            interactibleManager.playerManager = this;
            interactibleManager.RunInteraction();
        }
    }

    private void HandlePlayerSanity()
    {
        float sanityValue = (1 + 0.01f * (100 - playerHappiness)) * 0.1f * (playerAddiction);

        playerSanity -= sanityValue * Time.deltaTime;
    }
}
