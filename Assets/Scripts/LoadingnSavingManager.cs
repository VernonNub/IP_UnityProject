using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class LoadingnSavingManager : MonoBehaviour
{
    private string directoryPath = Application.dataPath + "/Scripts/GameData";
    private string fileName = "NPCConversations.json";

    private void Start()
    {
        
        DialougeManager.instance.npcConversations = LoadData();
        //SaveData();
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void SaveData()
    {
        string fullPath = Path.Combine(directoryPath, fileName);

        try
        {
            Directory.CreateDirectory(Path.GetFileName(fullPath));

            string dataToStore = JsonConvert.SerializeObject(DialougeManager.instance.npcConversations, Formatting.Indented);

            Debug.Log(dataToStore);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter write = new StreamWriter(stream))
                {
                    Debug.Log("saving");
                    write.Write(dataToStore);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    private Dictionary<string, Dictionary<int, Dictionary<string, object>>> LoadData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("NPCConversations");

        if (jsonFile == null)
        {
            Debug.LogError("NPCConversations.json NOT FOUND!");
            return new Dictionary<string, Dictionary<int, Dictionary<string, object>>>();
        }

        Debug.Log("NPCConversations.json FOUND!");

        try
        {
            var loadedData =
                JsonConvert.DeserializeObject<
                    Dictionary<string, Dictionary<int, Dictionary<string, object>>>
                >(jsonFile.text);

            Debug.Log("JSON loaded successfully!");

            return loadedData;
        }
        catch (Exception e)
        {
            Debug.LogError("JSON failed to load!");
            Debug.LogException(e);

            return new Dictionary<string, Dictionary<int, Dictionary<string, object>>>();
        }
    }
}
