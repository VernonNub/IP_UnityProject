using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using Newtonsoft.Json.Linq;
using JetBrains.Annotations;

public class DialougeManager : MonoBehaviour
{
    public static DialougeManager instance;
    [SerializeField] PlayerManager player;
    public AIManager ai;

    public string speaker = "who?";
    private bool goNext = false;

    [Header("DialougeBoxUiElements")]
    public Canvas dialougeUI;
    public TMP_Text dialouge;
    public TMP_Text speakerName;
    public GameObject option1;
    public GameObject option2;
    public TMP_Text option1Text;
    public TMP_Text option2Text;

    [Header("TypeWriterFX stats")]
    [SerializeField] float textSpeed = 20f;
    public bool isTyping;

    [Header("DialougeTexts")]
    //Conversation (ALL POSSIBLE CONVOS FOR NPC)
    public Dictionary<string, Dictionary<int, Dictionary<string, object>>> npcConversations =  new Dictionary<string, Dictionary<int, Dictionary<string, object>>>()
    {
        
    };

    //Keeps the index of dialouge progress
    [SerializeField] int dialougeIndex = 1;
    //DisplayText
    private string dialougeTextToDisplay;
    //ConversationName
    public string convoName;

    public bool isFixed = false;


    private List<int> chooseConvo = new List<int>()
    {
        0,
        0
    };


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(dialougeUI);
    }

    private void OnEnable()
    {
        //Add listeners for onclick
        option1.GetComponentInChildren<Button>().onClick.AddListener(() => ChooseOption(1));
        option2.GetComponentInChildren<Button>().onClick.AddListener(() => ChooseOption(2));
    }

    public void Fastforward()
    {
        if(isTyping)
        {
            StopAllCoroutines();
            dialouge.text = dialougeTextToDisplay;
            isTyping = false;
            StartCoroutine(DisplayOptions());
        }
        else if (goNext)
        {
            goNext = false;
            RunConversation();
        }
    }   
        
    private void ChooseConversation()
    {
        chooseConvo[0] = GameManager.instance.storyProgress;
        chooseConvo[1] = GameManager.instance.sceneProgress;
    }

    public void RunConversation()
    {
        if(!isFixed)
            ChooseConversation();

        convoName = string.Empty;
        foreach(int i in chooseConvo)
        {
            convoName += i.ToString();
        }
        convoName += "Conversation" + speaker;

        if (!npcConversations.ContainsKey(convoName))
        {
            CloseUI();
            return;
        }

        OpenUI();

        //Get the text to display
        dialougeTextToDisplay = npcConversations[convoName][dialougeIndex]["Text"].ToString();
        speakerName.text = speaker;
        StartCoroutine(TypeOutDialouge());

    }

    private IEnumerator DisplayOptions()
    {
        //If dialouge has no options
        if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option1Result"]) == 0)
        {
            option1.SetActive(false);
            option2.SetActive(false);

            //Option 1 determines if there are options or not, option 2 determines where the convo goes when there are no options
            if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option2Result"]) == -1)
            {
                //Negative = end of dialouge --> close UI, changes dialouge back to 1 (Start of every convo)
                CloseUI();
            }
            else if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option2Result"]) == -2)
            {
                //Negative = end of dialouge , -2 = change scene
                GameManager.instance.storyProgress += 1;
                GameManager.instance.ChangeScene(GameManager.instance.storyProgress + 1);
                CloseUI();
            }
            else if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option2Result"]) == -3)
            {
                //Negative = end of dialouge , -3 = change to roam scene
                GameManager.instance.storyProgress += 1;
                GameManager.instance.ChangeScene(4);
                CloseUI();
            }
            else if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option2Result"]) == -4)
            {
                GameManager.instance.sceneProgress += 1;
                CloseUI();
            }
            else if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option2Result"]) == -5)
            {
                GameManager.instance.sceneProgress += 2;
                CloseUI();
            }
            else
            {
                dialougeIndex = Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option2Result"]);
                goNext = true;
            }
        }
        //If dialouge has options
        else
        {
            option1.SetActive(true);
            option2.SetActive(true);

            //Update buttons to contain the options
            option1Text.text = npcConversations[convoName][dialougeIndex]["Option1"].ToString();
            option2Text.text = npcConversations[convoName][dialougeIndex]["Option2"].ToString();
        }

        yield return null;
    }

    private IEnumerator TypeOutDialouge()
    {
        isTyping = true;

        dialouge.text = string.Empty;
        float delay = 1f / textSpeed;

        //Types out eacher character 1 by 1 and waits to create the typewriter FX
        foreach (char c in dialougeTextToDisplay)
        {
            dialouge.text += c;
            yield return new WaitForSeconds(delay);
        }

        //Shows Options
        isTyping = false;

        yield return DisplayOptions();
    }

    private void ChooseOption(int option)
    {
        //Removes options
        option1.SetActive(false);
        option2.SetActive(false);

        //Changes the dialougeIndex and changes the playerStats
        JToken statData = (JToken)npcConversations[convoName][dialougeIndex]["Option" + option + "Stat"];
        ChangePlayerStats(statData.ToObject<List<float>>());

        if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option" + option + "Result"]) == -1)
        {
            //Negative = end of dialouge --> close UI, changes dialouge back to 1 (Start of every convo)
            CloseUI();
        }
        else if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option" + option + "Result"]) == -2)
        {
            //Negative = end of dialouge , -2 = change scene
            GameManager.instance.storyProgress += 1;
            GameManager.instance.ChangeScene(GameManager.instance.storyProgress + 1);
            CloseUI();
        }
        else if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option" + option + "Result"]) == -3)
        {
            //Negative = end of dialouge , -3 = change to roam scene
            GameManager.instance.storyProgress += 1;
            GameManager.instance.ChangeScene(4);
            CloseUI();
        }
        else if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option" + option + "Result"]) == -4)
        {
            GameManager.instance.sceneProgress += 1;
            CloseUI();
        }
        else if (Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option" + option + "Result"]) == -5)
        {
            GameManager.instance.sceneProgress += 2;
            CloseUI();
        }
        else
        {
            dialougeIndex = Convert.ToInt32(npcConversations[convoName][dialougeIndex]["Option" + option + "Result"]);
            RunConversation();
        }
    }

    private void ChangePlayerStats(List<float> stats)
    {
        //Changes the playerstats based on each item in lists (Fixed: addiction, happiness, npc  relationship, npc happines)
        player.playerAddiction += stats[0];
        player.playerHappiness += stats[1];

        ai.relationship += stats[2];
        ai.happiness += stats[3];
    }

    private void CloseUI()
    {
        dialougeIndex = 1;
        dialougeUI.gameObject.SetActive(false);
        isFixed = false;
        Cursor.lockState = CursorLockMode.Locked;
        ai.StopTalkingToPlayer();
    }

    private void OpenUI()
    {
        dialougeUI.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
