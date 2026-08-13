using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;
using UnityEditor.Search;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Stats")]
    public float playerHealth = 100;
    public float playerSanity = 100;
    public float playerAddiction = 0;
    public float playerHappiness = 50;

    [Header("RayCast")] 
    [SerializeField] float raycastLength = 3;
    private int mask = (1 << 6);

    [Header("Inventory")]
    public List<string> inventory = new List<string>();

    [Header("Components")]
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject playerFollowCamera;
    public CharacterController cc;
    public GameObject checkPoint;

    [SerializeField] InteractibleManager interactibleManager;

    private void OnEnable()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(playerCamera);
        DontDestroyOnLoad(playerFollowCamera);
    }

    private void Update()
    {
        HandleRayCast();
        HandlePlayerSanity();

        if(playerHealth <= 0)
        {
            HandleDeath();
        }
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
            UIManager.instance.ShowInteractPrompt(interactibleManager.interactibleName, interactibleManager.interactType);
        }
        else
        {
            interactibleManager = null;
            UIManager.instance.interactPrompt.SetActive(false);
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
        if(playerSanity >= 0)
        {
            float sanityValue = (1 + 0.01f * (100 - playerHappiness)) * 0.1f * (playerAddiction);
            playerSanity -= sanityValue * Time.deltaTime;
        }
        else
        {
            playerHealth -= 10 * Time.deltaTime;
        }
        
    }

    void OnClick()
    {
        DialougeManager.instance.Fastforward();
    }

    private void HandleDeath()
    {
        UIManager.instance.ShowDeathPopUp();
    }

    public void ResetPlayer()
    {
        cc.enabled = false;
        gameObject.transform.position = GameObject.Find("CheckPoint").transform.position;
        cc.enabled = true;

        GameManager.instance.transform.position = GameObject.Find("CheckPoint").transform.position;

        playerAddiction = 0;
    }
}
