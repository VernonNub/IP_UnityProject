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
}
