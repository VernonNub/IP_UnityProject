using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerManager playerManager;

    public GameObject weijie;

    public int currentScene = 0;

    public float NPC1Happiness = 0;
    public float NPC1Relationship = 0;
    public Transform NPC1Transform;
    public float NPC2Happiness = 0;
    public float NPC2Relationship = 0;
    public Transform NPC2Transform;

    [Header("Story Progression")]
    public int storyProgress = 0;
    public int sceneProgress = 1;

    public AudioSource bgm;
    public AudioClip normalBGM;
    public AudioClip alarmBGM;
    public AudioClip rainBGM;
    public Material skyBoxNight;
    public GameObject tutorialItems;

    public Dictionary<int, List<string>> storyDetails = new Dictionary<int, List<string>>()
    {
        {0, new List<string>(){"Walk Around", "Talk to the NPC"} }, //Tutorial
        {1, new List<string>(){"Go for recess"}}, //Starting scenes
        {2, new List<string>(){"Go to canteen & talk!"}},
        {3, new List<string>(){"Talk to Nigel and Wei Jie"}}, //Roam
        {4, new List<string>(){"Check up on Nigel", "!!! Hide the VAPE!", "Talk to Wei Jie"}},
        {5, new List<string>(){"Talk to Nigel and Wei Jie"}}, //Roam 2
        {6, new List<string>(){"A crazy request!", "Oh no Wei Jie found out!", "Who do I choose?"}}, //Money Stealing
        {7, new List<string>(){"Talk to Nigel and Wei Jie"}}, //Roam 3
        {8, new List<string>(){"Talk to Nigel", "Its so addicting!", "YOU DON'T WANT TO VAPE?"}}, //Ending Pt 1 No 1 (VP relationship higher)
        {9, new List<string>(){"Talk to Wei Jie about Nigel", "Steal the vape", "Talk to Nigel about his addiction"}}, //Ending Pt1 No 2 (SC relationship higher)
    };

    public Dictionary<string, string> missionDetails = new Dictionary<string, string>()
    {
        {"Walk Around", "Use WASD to walk around and explore the area"},
        {"Talk to the NPC", "Core gameplay of our game is interacting with NPCs, try talking to one!"},
        {"Look For A Spot To Vape", "During the game, your sanity could drain, when its fully drained your health starts to drain. To bring your sanity back, step into a vaping zone! They are green!"},
        {"Go for recess", "Its recess! Your friends Nigel and Wei Jie are asking to go for recess together. Who will you picK?"},
        {"Talk to Nigel and Wei Jie", "You got some free time, go talk to your friends and find out whats going on. Maybe you could go back to class??"},
        {"Check up on Nigel", "Why is Nigel coughing? Let me go to the toilet to check up on him!"},
        {"!!! Hide the VAPE!", "The fire alarm rang? They are going to catch us! QUICK hide the vape before anyone sees us."},
        {"A crazy request!", "Nigel just asked you to steal some of the money from the donation jar. Will you do it?"},
        {"Oh no Wei Jie found out!", "Wei Jie found out I stole the money! Do I cover it up or snitch on Nigel?"},
        {"Who do I choose?", "Hmm Nigel wants me to take the money from the jar but i dont want to do it. Should I snitch on him?"},
        {"Talk to Nigel", "I want to try the vape that Nigel has been using!"},
        {"Its so addicting!", "I can't stop using the VAPE, I need to keep vaping."},
        {"YOU DON'T WANT TO VAPE?", "Run away from Nigel, he wants to fight you!"},
        {"Talk to Wei Jie about Nigel", "Wei Jie wants to talk to you about Nigel."},
        {"Steal the vape", "Find Nigel's bag and steal the vape as planned!"},
        {"Talk to Nigel about his addiction", "Try to talk to Nigel and see if you can convince him to quit!"},
        {"Talk to Wei Jie", "Wei Jie is look for you because you are missing from the fire drill."},
        {"Go to canteen & talk!", "Follow your friends to the canteen. When you reach, talk to your friends!" }
    };

    public string sceneName = "MainMenu";

    private bool canPlay = true;

    public GameObject smoke;
    public GameObject rain1;

    private void Update()
    {
        if(storyProgress == 0 && sceneProgress == 3)
        {
            playerManager.playerAddiction = 50;
        }

        if(canPlay)
        {
            HandleBGM();
        }

        if(storyProgress >= 7)
        {
            RenderSettings.skybox = skyBoxNight;
            rain1.SetActive(true);
        }

        if(storyProgress == 4 || sceneProgress == 2)
        {
            smoke.SetActive(true);
        }

        if(storyProgress > 0)
        {
            if(GameObject.Find("TutorialItems") != null)
            {
                GameObject.Find("TutorialItems").SetActive(false);
            }
        }
    }

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

        bgm = gameObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ChangeScene(string scene)
    {
        UIManager.instance.GUI.SetActive(false);
        UIManager.instance.loadingText.SetActive(true);

        SceneManager.LoadScene(scene);
    }

    public void IncreaseProgress()
    {
        storyProgress += 1;
        sceneProgress = 1;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != sceneName)
        {
            weijie = GameObject.Find("Wei Jie");

            //Gets the different component after entering game scenes
            sceneName = scene.name;

            if(GameObject.Find("CheckPoint") != null)
            {
                playerManager.ResetPlayer();
            }
            
            UIManager.instance.GUI.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;

            if(scene.name == "Toilet")
            {
                weijie.SetActive(false);
            }
        }

        UIManager.instance.loadingText.SetActive(false);
        canPlay = true;
    }

    private void HandleBGM()
    {
        canPlay = false;
        if (storyProgress >= 7)
        {
            bgm.clip = rainBGM;
            bgm.volume = 0.017f;

            bgm.Play();
        }
        else
        {
            bgm.clip = normalBGM;
            bgm.volume = 0.2f;

            bgm.Play();
        }
    }

}
