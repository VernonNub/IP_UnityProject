using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;

public class InteractibleManager : MonoBehaviour
{
    [Header("Interaction Details")]
    public PlayerManager playerManager;
    public string interactibleName;
    public string requiredItem = "";

    public int vapeLocation;

    public bool isVapePlaced= false;

    public enum InteractType
    {
        NPC,
        Door,
        Collect,
        Windows,
        HideVape,
        
    }

    public InteractType interactType;

    public void RunInteraction()
    {
        if (requiredItem == "" || playerManager.inventory.Contains(requiredItem))
        {
            switch (interactType)
            {
                case InteractType.Collect:
                    playerManager.inventory.Add(name);
                    Destroy(gameObject);
                    break;

                case InteractType.NPC:
                    AIManager manager = gameObject.GetComponent<AIManager>();
                    manager.playerManager = playerManager;
                    manager.TalkToPlayer();

                    DialougeManager.instance.ai = manager;

                    DialougeManager.instance.speaker = interactibleName;
                    DialougeManager.instance.RunConversation();
                    break;

                case InteractType.HideVape:
                    if(isVapePlaced == false)
                    {
                        //Check the vape position if its out in the open
                        if (vapeLocation % 2 == 0)
                        {
                            //Run SC sees dialouge
                            DialougeManager.instance.convoName = "431ConversationWei Jie";
                            GameManager.instance.sceneProgress += 1;
                            DialougeManager.instance.isFixed = true;
                        }
                        else
                        {
                            //Run VP sees dialouge
                            DialougeManager.instance.convoName = "432ConversationWei Jie";
                            GameManager.instance.sceneProgress += 1;
                            DialougeManager.instance.isFixed = true;
                        }

                        GameManager.instance.weijie.SetActive(true);

                        isVapePlaced = true;
                    }
                    
                    break;
            }
        }
    }
}
