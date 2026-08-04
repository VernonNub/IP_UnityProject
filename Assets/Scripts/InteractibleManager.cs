using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;

public class InteractibleManager : MonoBehaviour
{
    [Header("Interaction Details")]
    public PlayerManager playerManager;
    public string name;
    public string requiredItem = "";

    public enum InteractType
    {
        NPC,
        Door,
        Collect,
    }

    public InteractType interactType;

    public void RunInteraction()
    {
        if (requiredItem == "" || playerManager.inventory.Contains(requiredItem))
        {
            switch(interactType)
            {
                case InteractType.Collect:
                    playerManager.inventory.Add(name);
                    Destroy(gameObject);
                    break;
                
                case InteractType.NPC:
                    AIManager manager = gameObject.GetComponent<AIManager>();
                    if(manager.isTalking)
                    {
                        manager.changeState = true;
                        manager.isTalking = false;
                    }
                    else
                    {
                        manager.playerManager = playerManager;
                        manager.TalkToPlayer(); 
                    }
                    break;
            }
        }
    }
}
