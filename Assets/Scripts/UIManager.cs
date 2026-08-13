using System.Collections;
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

    public GameObject endingText;

    public bool isShowed = false;

    public GameObject loadingText;

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

        ShowEnding();
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

    private void ShowEnding()
    {
        if(!isShowed)
        {
            if (GameManager.instance.storyProgress == 8 && GameManager.instance.sceneProgress == 2)
            {
                endingText.SetActive(true);
                StartCoroutine(TypeOutEnding("Gary ends up getting addicted to vaping. Months of vaping caused his health condition to worsened. It is easy to fall prey to such temptations. If you are going through a hard time, seek help from others \n \n The End"));
            }

            if (GameManager.instance.storyProgress == 8 && GameManager.instance.sceneProgress == 3)
            {
                endingText.SetActive(true);
                StartCoroutine(TypeOutEnding("Nigel could not control his emotions and punched Gary in the face causing him to end up in the hospital. Vapes are extremely harmful towards your mental well-being. Before using a vape, consider if it is worth it. Vapes are also illegal and possession of vape could include jail time. \n \n The End"));
            }

            if (GameManager.instance.storyProgress == 9 && GameManager.instance.sceneProgress == 2)
            {
                endingText.SetActive(true);
                StartCoroutine(TypeOutEnding("After taking away Nigel's vape, he had a mental episode during a lesson and injured himself. Sometimes what we think might help someone might not be the appropriate solution. Forcefully taking away an addict's vape could worsen their mental well-beings. It is better to seek advice or help from a professional before acting on your own. \n \n The End"));
            }

            if (GameManager.instance.storyProgress == 9 && GameManager.instance.sceneProgress == 3)
            {
                endingText.SetActive(true);
                StartCoroutine(TypeOutEnding("Gary and Wei Jie talked to Nigel after school. With Gary and Wei Jie there to listen, Nigel opened up to them about the things he has been going through in his personal life. They decided to help Nigel out wherever possible, so that Nigel will not be so stressed in school. With their help, they convinced Nigel to seek professional help to quit vaping. Until September 1st, individuals who voluntarily seek help will not face any penalties or receive an offense record. \n \n The End"));
            }
        }
    }

    private IEnumerator TypeOutEnding(string dialouge)
    {
        isShowed = true;

        GUI.SetActive(false);

        endingText.GetComponentInChildren<TMP_Text>().text = string.Empty;
        float delay = 1f / 15f;

        //Types out eacher character 1 by 1 and waits to create the typewriter FX
        foreach (char c in dialouge)
        {
            endingText.GetComponentInChildren<TMP_Text>().text += c;
            yield return new WaitForSeconds(delay);
        }

        yield return null;
    }
}
