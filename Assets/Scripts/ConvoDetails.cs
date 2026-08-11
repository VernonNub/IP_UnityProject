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
