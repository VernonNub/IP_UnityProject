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
        string fullPath = Path.Combine(directoryPath, fileName);

        Dictionary<string, Dictionary<int, Dictionary<string, object>>> loadedData = null;
        if(File.Exists(fullPath))
        {
            try
            {
                Debug.Log("Loading");
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                        Debug.Log("Loaded");
                        Debug.Log(dataToLoad);
                    }
                }

                loadedData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<int, Dictionary<string, object>>>>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        return loadedData;
    }
}
