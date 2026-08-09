using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class DialougeManager : MonoBehaviour
{
    public static DialougeManager instance;

    [Header("DialougeBoxUiElements")]
    public Canvas dialougeUI;
    public TMP_Text dialouge;
    public TMP_Text speakerName;
    public Button option1;
    public Button option2;
    public TMP_Text option1Text;
    public TMP_Text option2Text;

    private string dialougeTextToDisplay;

    [Header("TypeWriterFX stats")]
    [SerializeField] float textSpeed = 20f;
    public bool isTyping;
    public bool isOpen;

    [Header("DialougeTexts")]
    private Dictionary<int, Dictionary<string, object>> HappyConverstion = new Dictionary<int, Dictionary<string, object>>()
    {
        {1, new Dictionary<string, object>()
            {
                {"Text", "pneumonoultramicroscopicsilicovolcanoconiosis"},
                {"Option1", "should i pneumonoultramicroscopicsilicovolcanoconiosis" },
                {"Option2", "I should leave" },
                {"Option1Result", 1 },
                {"Option2Result", -1 },
                {"Option1Stat", new List<float>(){0, 0, 0, 0} },
                {"Option2Stat", new List<float>(){0, 0, 0, 0} }
            }
        },

        {2, new Dictionary<string, object>()
            {
                {"Text", "pneumonoultramicroscopicsilicovolcanoconiosis"},
                {"Option1", "should i pneumonoultramicroscopicsilicovolcanoconiosis" },
                {"Option2", "I should leave" },
                {"Option1Result", 1 },
                {"Option2Result", -1 },
                {"Option1Stat", new List<float>(){0, 0, 0, 0} },
                {"Option2Stat", new List<float>(){0, 0, 0, 0} }
            }
        },
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
        DontDestroyOnLoad(dialougeUI);
    }

    public void DisplayDialouge(string speaker)
    {
        speakerName.text = speaker;
        StartCoroutine(TypeOutDialouge());
    }

    public void Fastforward()
    {
        StopAllCoroutines();
        dialouge.text = dialougeTextToDisplay;
        isTyping = false;
    }

    public void RunConversation()
    {

    }

    private IEnumerator TypeOutDialouge()
    {
        isTyping = true;

        dialouge.text = string.Empty;
        float delay = 1f / textSpeed;

        foreach (char c in dialougeTextToDisplay)
        {
            dialouge.text += c;
            yield return new WaitForSeconds(delay);
        }

        isTyping = false;
    }
}
