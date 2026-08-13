using TMPro;
using Unity.Multiplayer.Center.Common.Analytics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] PlayerManager player;
    [SerializeField] Slider sanityBar;
    [SerializeField] Slider healthBar;
    public GameObject interactPrompt;
    public GameObject deathPopUp;

    public GameObject UIElement;

    public GameObject missionPanel;
    public TMP_Text missionText;
    public TMP_Text missionDescription;

    public GameObject GUI;

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

        DontDestroyOnLoad(UIElement);
    }

    void Update()
    {
        UpdateStatusBars();
        UpdateMission();
    }

    private void UpdateMission()
    {
        if (GameManager.instance.storyDetails[GameManager.instance.storyProgress][GameManager.instance.sceneProgress -1] == null || GameManager.instance.missionDetails[GameManager.instance.storyDetails[GameManager.instance.storyProgress][GameManager.instance.sceneProgress - 1]] == null)
        {
            missionPanel.SetActive(false);
        }
        else
        {
            missionText.text = GameManager.instance.storyDetails[GameManager.instance.storyProgress][GameManager.instance.sceneProgress - 1];
            missionDescription.text = GameManager.instance.missionDetails[GameManager.instance.storyDetails[GameManager.instance.storyProgress][GameManager.instance.sceneProgress - 1]];
        }
    }

    private void UpdateStatusBars()
    {
        if(sanityBar != null && healthBar != null)
        {
            sanityBar.maxValue = 100;
            sanityBar.value = player.playerSanity;
            healthBar.maxValue = 100;
            healthBar.value = player.playerHealth;
        }
        else
        {
            sanityBar = GameObject.Find("SanityBar").GetComponent<Slider>();
            healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        }
        
    }

    public void ShowInteractPrompt(string name, InteractibleManager.InteractType interactType)
    {
        if(interactPrompt != null)
        {
            TMP_Text text = interactPrompt.GetComponentsInChildren<TMP_Text>()[1];
            if(interactType == InteractibleManager.InteractType.NPC)
            {
                text.text = "Talk to " + name;
            }
            else
            {
                text.text = "Interact with " + name;
            }

            interactPrompt.SetActive(true);
        }
    }

    public void ShowDeathPopUp()
    {
        deathPopUp.SetActive(true);
    }
}
