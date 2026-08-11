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
      "Hallway"
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

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(scenes[index]);
    }
}
