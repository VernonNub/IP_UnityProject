using UnityEngine;
using System.Collections.Generic;

public class PlaceHolderData : MonoBehaviour
{
    public Dictionary<string, Dictionary<int, Dictionary<string, object>>> npcConversations =  new Dictionary<string, Dictionary<int, Dictionary<string, object>>>()
    { 
        //Each dialouge in the conversation
        //111 determines which convo and NPC1 is the name of the NPC
        //for 111 first one is based on story progression (if your at story progression 2, then its 2)
        //Second one is based on NPC's happiness 1 if its angry (Happiness <= 25) 2 if sad (<=50) 3 if neutral (<=75) and 4 if happy (<=100)
        //Last one is relationship with player 1 if bad (<=50) 2 if good (<=100)
        { "121ConversationNPC1", new Dictionary<int, Dictionary<string, object>>()
            {
                //Details of each dialouge (What are the options? what are the results? How does the stat change?)
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz"},
                        {"Option1", "no abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz" },
                        {"Option2", "I should leave" },
                        {"Option1Result", 2 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },

                {2, new Dictionary<string, object>()
                    {
                        {"Text", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz"},
                        {"Option1", "no abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz" },
                        {"Option2", "I should leave" },
                        {"Option1Result", 0 },
                        {"Option2Result", -1 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            } 
        }
    };    
}

// Recess
public class PlaceHolderData : MonoBehaviour
{
    public Dictionary<string, Dictionary<int, Dictionary<string, object>>> npcConversations =  new Dictionary<string, Dictionary<int, Dictionary<string, object>>>()
    { 
        //Each dialouge in the conversation
        //111 determines which convo and NPC1 is the name of the NPC
        //for 111 first one is based on story progression (if your at story progression 2, then its 2)
        //Second one is based on NPC's happiness 1 if its angry (Happiness <= 25) 2 if sad (<=50) 3 if neutral (<=75) and 4 if happy (<=100)
        //Last one is relationship with player 1 if bad (<=50) 2 if good (<=100)
        //---
        //Scene 2 free roam: aft recess
        { "21ConversationSC", new Dictionary<int, Dictionary<string, object>>()
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
        { "41ConversationSC", new Dictionary<int, Dictionary<string, object>>()
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
        { "61ConversationSC", new Dictionary<int, Dictionary<string, object>>()
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
}



