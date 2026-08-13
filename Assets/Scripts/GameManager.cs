using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("GameInfos")]
    public Dictionary<string, string> items = new Dictionary<string, string>()
    {
        {"Vape", "What is this interesting device? I hear it can make cool smoke out of it! *Increases your happiness by 5 for 1min and increases your addiction by 5"},
    };

    private List<string> scenes = new List<string>()
    {
      "MainMenu",
      "Tutorial",
      "Classroom",
      "Canteen",
      "Roam",
      "Toilet",
      "Roam1",
      "Clasroom2",
      "Roam 3",
      "Hallway",
      "Classroom3",
      "Classroom4"
    };

    public int currentScene = 0;

    [Header("Story Progression")]
    public int storyProgress = 0;
    public int sceneProgress = 1;

    public Dictionary<int, List<string>> storyDetails = new Dictionary<int, List<string>>()
    {
        {0, new List<string>(){"Walk Around", "Talk to the NPC", "Look For A Spot To Vape" } }, //Tutorial
        {1, new List<string>(){"Go for recess"}}, //Starting scenes
        {2, new List<string>(){"Talk to your friends"}},
        {3, new List<string>(){"Talk to Nigel and Wei Jie"}}, //Roam
        {4, new List<string>(){"Check up on Nigel", "!!! Hide the VAPE!", "Talk to Wei Jie"}},
        {5, new List<string>(){"Talk to Nigel and Wei Jie"}}, //Roam 2
        {6, new List<string>(){"A crazy request!", "Oh no Wei Jie found out!", "Who do I choose?"}}, //Money Stealing
        {7, new List<string>(){"Talk to Nigel and Wei Jie"}}, //Roam 3
        {8, new List<string>(){"Talk to Nigel", "Its so addicting!", "YOU DON'T WANT TO VAPE?"}}, //Ending Pt 1 No 1 (VP relationship higher)
        {9, new List<string>(){"Talk to Wei Jie", "Steal the vape", "Talk to Nigel about his addiction"}}, //Ending Pt1 No 2 (SC relationship higher)
    };

    public Dictionary<string, string> missionDetails = new Dictionary<string, string>()
    {
        {"Walk Around", "Use WASD to walk around and explore the area"},
        {"Talk to the NPC", "Core gameplay of our game is interacting with NPCs, try talking to one!"},
        {"Look For A Spot To Vape", "During the game, your sanity could drain, when its fully drained your health starts to drain. To bring your sanity back, step into a vaping zone!"},
        {"Go for recess", "Its recess! Your friends Nigel and Wei Jie are asking to go for recess together. Who will you picK?"},
        {"Talk to Nigel and Wei Jie", "You got some free time, go talk to your friends and find out whats going on."},
        {"Check up on Nigel", "Why is Nigel coughing? Let me go to the toilet to check up on him!"},
        {"!!! Hide the VAPE!", "The fire alarm rang? They are going to catch us! QUICK hide the vape before anyone sees us."},
        {"A crazy request!", "Nigel just asked you to steal some of the money from the donation jar. Will you do it?"},
        {"Oh no Wei Jie found out!", "Wei Jie found out I stole the money! Do I cover it up or snitch on Nigel?"},
        {"Who do I choose?", "Hmm Nigel wants me to take the money from the jar but i dont want to do it. Should I snitch on him?"},
        {"Talk to Nigel", "I want to try the vape that Nigel has been using!"},
        {"Its so addicting!", "I can't stop using the VAPE, I need to keep vaping."},
        {"YOU DON'T WANT TO VAPE?", "Run away from Nigel, he wants to fight you!"},
        {"Talk to Wei Jie", "Wei Jie wants to talk to you about Nigel."},
        {"Steal the vape", "Find Nigel's bag and steal the vape as planned!"},
        {"Talk to Nigel about his addiction", "Try to talk to Nigel and see if you can convince him to quit!"},
        {"Talk to Wei Jie", "Wei Jie is look for you because you are missing from the fire drill."}
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
    }

    public void ChangeScene(int index)
    {
        currentScene = index;
        SceneManager.LoadScene(scenes[index]);

        sceneProgress = 1;
    }
}
