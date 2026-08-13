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
        },

        { "31ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //MC talks to VP and he complains about recess being over
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Recess over already? Do we really have to go for classes."},
                        {"Option1", "I get you, but it's still important, you know." },
                        {"Option2", "I know right? It's just too short..." },
                        {"Option1Result", -1 },
                        {"Option2Result", 1 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 0, 0 } }
                    }
                },
            }
        },


        { "51ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //VP wants to leave early and go vape
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Nothing is even happening... You wanna just leave?"},
                        {"Option1", "Can't, we'll be caught" },
                        {"Option2", "Sure but... How?" },
                        {"Option1Result", -1 },
                        {"Option2Result", 1 },
                        {"Option1Stat", new List<float>(){0, 0, 0, 0 } },
                        {"Option2Stat", new List<float>(){0, 0, 5, 10 } }
                    }
                },
            }
        },

         { "71ConversationNigel", new Dictionary<int, Dictionary<string, object>>()
            {
                //VP wants to leave early and go vape
                {1, new Dictionary<string, object>()
                    {
                        {"Text", "Days like this are perfect for you for you to let a little lose. C'mon, just give it a try."},
                        {"Option1", "Not now, not now..." },
                        {"Option2", "Yup sure, let's go." },
                        {"Option1Result", -2 },
                        {"Option2Result", 1 },
                        {"Option1Stat", new List<float>(){10, 0, -10, 0 } },
                        {"Option2Stat", new List<float>(){20, 0, 10, 10 } }
                    }
                },
            }
        },
    };    
}


