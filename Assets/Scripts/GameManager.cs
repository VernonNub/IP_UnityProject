using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerManager playerManager;

    [Header("GameInfos")]
    public Dictionary<string, string> items = new Dictionary<string, string>()
    {
        {"Vape", "What is this interesting device? I hear it can make cool smoke out of it! *Increases your happiness by 5 for 1min and increases your addiction by 5"},
    };

    public int playerPOV = 1;
    public Dictionary<int, Dictionary<string, float>> povStats = new Dictionary<int, Dictionary<string, float>>()
    {
        {1, new Dictionary<string, float>(){ {"Sanity", 100}, { "Addiction", 0 }, { "Happiness", 50 } } },
    };

    [Header("Story Progression")]
    public int storyProgress = 0;
    public Dictionary<string, string> storyEvents = new Dictionary<string, string>();

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

    private void ChangePOV(int pov)
    {
        //Updates the Dictionary (Saves the current player stats)
        povStats[playerPOV]["Sanity"] = playerManager.playerSanity;
        povStats[playerPOV]["Addiction"] = playerManager.playerAddiction;
        povStats[playerPOV]["Happiness"] = playerManager.playerHappiness;

        //Changes the POV
        playerPOV = pov;

        //Updates the playerManager
        playerManager.playerSanity = povStats[pov]["Sanity"];
        playerManager.playerAddiction = povStats[pov]["Addiction"];
        playerManager.playerHappiness = povStats[pov]["Happiness"];
    }
}
