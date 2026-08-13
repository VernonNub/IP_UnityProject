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
        { "02ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Welcome to the game!"},
                        {"Option1", "Yay" },
                        {"Option2", "Yippe" },
                        {"Option1Result", -4 },
                        {"Option2Result", -4 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0} },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "11ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Oi Gary, class over already. You take so long for what, want go canteen eat?"},
                        {"Option1", "Ok bro no problem!" },
                        {"Option2", "Hmm let me think" },
                        {"Option1Result", 2 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 10 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Come ah lets go down now!"},
                        {"Option1", "" },
                        {"Option2", "" },
                        {"Option1Result", 0 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "11ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Oi Gary, class over already. You take so long for what, want go canteen eat?"},
                        {"Option1", "Ok bro no problem!" },
                        {"Option2", "Hmm let me think" },
                        {"Option1Result", 2 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 10 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Come ah lets go down now!"},
                        {"Option1", "" },
                        {"Option2", "" },
                        {"Option1Result", 0 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "21ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Sorry, I keep coughing recently. I'm not even sick, I don't know why I am liddat."},
                        {"Option1", "Anything happen recently that cause you to cough?" },
                        {"Option2", "LOL must be use too much phone!" },
                        {"Option1Result", 2 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Maybe, but I also don't know. Could be because I have been trying out this new thing recently."},
                        {"Option1", "Wah interesting, you must show me later!" },
                        {"Option2", "Hmm ok" },
                        {"Option1Result", -2 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "21ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "You know Nigel he has been acting weird recently. I knew he was always a weird person and did not like him."},
                        {"Option1", "Your right, hes been quite weird recently. What is going on with him." },
                        {"Option2", "Eh you want go buy food?" },
                        {"Option1Result", 2 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Yea, maybe don't hang out with him that often then?"},
                        {"Option1", "" },
                        {"Option2", "" },
                        {"Option1Result", 0},
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "41ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "What are you doing here! You come toilet for what!"},
                        {"Option1", "So thats why you cough so much! You are vaping." },
                        {"Option2", "Walao, isnt vaping illegal?" },
                        {"Option1Result", 2 },
                        {"Option2Result", 2 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Yes, but I have been under so much stress lately and vaping feels so nice. You should try, you will love it FOR SURE!"},
                        {"Option1", "Really that nice meh, ok I try one puff." },
                        {"Option2", "No thanks, I don't want. Its illegal and unhealthy." },
                        {"Option1Result", -4 },
                        {"Option2Result", -4 },
                        {"Option1Stat", new List<float>(){0, 0, +10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, -10, -10 } }
                    }
                },
            }
        },

        { "42ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Fire drill! OMG teacher mentioned this last week! They will find my vape!"},
                        {"Option1", "Quick hide your vape somewhere! Come I help!" },
                        {"Option2", "Eh you on your own bro. I don't want to be involved in this." },
                        {"Option1Result", -4 },
                        {"Option2Result", 2 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Just help me please. I treat you to a meal!"},
                        {"Option1", "Really that nice meh, ok I try one puff." },
                        {"Option2", "No thanks, I don't want. Its illegal and unhealthy." },
                        {"Option1Result", 0 },
                        {"Option2Result", -4 },
                        {"Option1Stat", new List<float>(){10, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "431ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Where the 2 of you go! Fire drill and both of you sitting in toilet doing WHAT?"},
                        {"Option1", "Nothing, I just needed to go toilet." },
                        {"Option2", "Eh I thought can just stay here?" },
                        {"Option1Result", -2 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "432ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "WHAT IS THAT. Both of you are vaping in here when you are supposed to assemble?"},
                        {"Option1", "That one not ours bro." },
                        {"Option2", "Oi please don't tell teacher." },
                        {"Option1Result", -2 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, -10, -10 } },
                        {"Option2Stat", new List<float>(){0, 0, -10, -10 } }
                    }
                },
            }
        },

        { "60ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Eh the class donation got how much?"},
                        {"Option1", "Roughly 203 dollar right now why leh?" },
                        {"Option2", "Why should I tell you?" },
                        {"Option1Result", 2 },
                        {"Option2Result", 3 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Can I take some? So much money, if I take abit no one will know right? You won't snitch also."},
                        {"Option1", "Hmm ok lor." },
                        {"Option2", "NO cannot one." },
                        {"Option1Result", -4 },
                        {"Option2Result", -4 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 10 } },
                        {"Option2Stat", new List<float>(){0, 0, -10, 0 } }
                    }
                },

                {3, new Dictionary<string, object>()
                    {
                        {"Text", "Walao can don't like that anot. Just curious want to know cannot is it?"},
                        {"Option1", "Ok lah I tell you. Inside got i think 203 dollars." },
                        {"Option2", "Don't be so kay poh." },
                        {"Option1Result", 2 },
                        {"Option2Result", -4 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, -10, 0 } }
                    }
                },
            }
        },

        { "62ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "What are you guys doing? Aren't you supposed to be keeping the donation money safe?"},
                        {"Option1", "Ya what, I am just keeping it in my bag!" },
                        {"Option2", "Sorry sorry, I wanted to look at the money. So nice seeing such a large sum of money." },
                        {"Option1Result", -2 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, -10, 0 } }
                    }
                },
            }
        },

        { "61ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Yo hows the donation jar looking?"},
                        {"Option1", "Its at 203 dollars. But can I talk to you about something?" },
                        {"Option2", "Its at 203 dollars" },
                        {"Option1Result", 2 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Sure, whats up?"},
                        {"Option1", "Nigel recently told me he wanted money and asked me to take some out of the donation money to give him. What should I do?" },
                        {"Option2", "You know what nevermind" },
                        {"Option1Result", 3 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {3, new Dictionary<string, object>()
                    {
                        {"Text", "Eh thats concerning. Did you know he vapes? He is likely to be asking money to buy more. I will let our form teacher know!"},
                        {"Option1", "Ok lah I tell you. Inside got i think 203 dollars." },
                        {"Option2", "Don't be so kay poh." },
                        {"Option1Result", 0 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "61ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Yo whats up bro. Got the money?"},
                        {"Option1", "No I do not have the money, I cannot steal from the money jar for you. What do you even need the money anyways?" },
                        {"Option2", "Its at 203 dollars" },
                        {"Option1Result", 2 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, -10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Bro, just take the money its not that deep. Its only 10 dollars anyways."},
                        {"Option1", "No I will not take it." },
                        {"Option2", "You know what nevermind" },
                        {"Option1Result", 3 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, -10, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {3, new Dictionary<string, object>()
                    {
                        {"Text", "Wow ok, I see how it is."},
                        {"Option1", "" },
                        {"Option2", "" },
                        {"Option1Result", 0 },
                        {"Option2Result", -2 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "81ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "I got the vape. Now you can vape as much as you want, whenever you want!"},
                        {"Option1", "Nice one! How much again?" },
                        {"Option2", "Hmm should I really do it?" },
                        {"Option1Result", 2 },
                        {"Option2Result", 3 },
                        {"Option1Stat", new List<float>(){0, 0, 1000, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Cheapest one, 30 dollars take it or leave it."},
                        {"Option1", "I will take it!" },
                        {"Option2", "Walao 30 dollars???" },
                        {"Option1Result", -4 },
                        {"Option2Result", 4 },
                        {"Option1Stat", new List<float>(){0, 0, 1000, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, -1000, 0 } }
                    }
                },

                {3, new Dictionary<string, object>()
                    {
                        {"Text", "Do't scared lah, its just a vape won't kill you one."},
                        {"Option1", "Ok lah how much?" },
                        {"Option2", "Are you sure? It so suspicious though." },
                        {"Option1Result", 2 },
                        {"Option2Result", 4 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, -1000, 0 } }
                    }
                },

                {4, new Dictionary<string, object>()
                    {
                        {"Text", "I GO THROUGH SO MUCH TROUBLE AND YOU TELL ME YOU DON'T WANT? "},
                        {"Option1", "" },
                        {"Option2", "" },
                        {"Option1Result", 0 },
                        {"Option2Result", -5 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "91ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "You look disturbed"},
                        {"Option1", "How can we prevent Nigel from vaping? I am concerned for his health." },
                        {"Option2", "Nigel has been coughing even more, can we help him?" },
                        {"Option1Result", 2 },
                        {"Option2Result", 2 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "Help that guy??? He does not deserve any help!"},
                        {"Option1", "Please" },
                        {"Option2", "Please" },
                        {"Option1Result", 3 },
                        {"Option2Result", 3 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {3, new Dictionary<string, object>()
                    {
                        {"Text", "Fine I will help, what do you want to do?"},
                        {"Option1", "Take his vape so that he cannot vape anymore?" },
                        {"Option2", "Talk to him, but be nice to him this time?" },
                        {"Option1Result", 4 },
                        {"Option2Result", 5 },
                        {"Option1Stat", new List<float>(){0, 0, -1000, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 1000, 0 } }
                    }
                },

                {4, new Dictionary<string, object>()
                    {
                        {"Text", "Ok lets do it!"},
                        {"Option1", "" },
                        {"Option2", "" },
                        {"Option1Result", 0 },
                        {"Option2Result", -4 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {5, new Dictionary<string, object>()
                    {
                        {"Text", "Fine..."},
                        {"Option1", "" },
                        {"Option2", "" },
                        {"Option1Result", 0 },
                        {"Option2Result", -4 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        { "31ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //MC talks to SC and asking MC to go back to his seat
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Recess is over, you should probably go back to your seat before the teacher comes."},
                        {"Option1", "Alright, I'll go back." },
                        {"Option2", "Just looking around." },
                        {"Option1Result", -1 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        // Scene 4 free roam: field
        { "51ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //SC asks MC to stay with the class because its a fire drill
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Stay with the class, it's a fire drill!"},
                        {"Option1", "Got it. I'll stay here." },
                        {"Option2", "Okay, relax man." },
                        {"Option1Result", -1 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },

        // Scene 6 free roam: gloomy hallway
        { "71ConversationWei Jie", new Dictionary<int, Dictionary<string, object>>()
            {
                //SC is stressed out and is dissappointed.
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Things are such a mess right now..."},
                        {"Option1", "I know, it's overwhelming." },
                        {"Option2", "I understand how you feel." },
                        {"Option1Result", -1 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        }
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

        convoName = string.Empty;
        foreach (int i in chooseConvo)
        {
            convoName += i.ToString();
        }
        convoName += "Conversation" + speaker;
    }

    public void RunConversation()
    {
        if(!isFixed)
        {
            ChooseConversation();
        }

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

    public void ChooseOption(int option)
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
