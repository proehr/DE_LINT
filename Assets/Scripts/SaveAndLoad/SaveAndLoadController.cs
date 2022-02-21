using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using DataStructures.Events;
using DataStructures.Variables;
using UnityEngine;

namespace SaveAndLoad
{
    public class SaveAndLoadController : MonoBehaviour
    {
        [SerializeField] private GameEvent onSaveGameplayData;
        [SerializeField] private GameEvent onLoadGameplayData;
        [SerializeField] private IntVariable saveFileNumber;
        [SerializeField] private List<ScriptableObject> gameplayData;


        internal static String dataDirectoryName = "GameplayData";

        [DllImport("__Internal")]
        private static extern void SyncFiles();

        [DllImport("__Internal")]
        private static extern void WindowAlert(string message);

        private void Awake()
        {
            onSaveGameplayData.RegisterListener(Save);
            onLoadGameplayData.RegisterListener(Load);
        }

        public void Save()
        {
            Debug.Log("Saving data");
            String dataPath = Path.Combine(Application.persistentDataPath, dataDirectoryName + saveFileNumber.value);
            try
            {
                if (!Directory.Exists(dataPath))
                {
                    Directory.CreateDirectory(dataPath);
                }

                foreach (ScriptableObject data in gameplayData)
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    FileStream fileStream;
                    String filePath = Path.Combine(dataPath, data.name + ".dat");
                    if (!File.Exists(filePath))
                    {
                        fileStream = File.Create(filePath);
                    }
                    else
                    {
                        File.WriteAllText(filePath, string.Empty);
                        fileStream = File.Open(filePath, FileMode.Open);
                    }

                    binaryFormatter.Serialize(fileStream, JsonUtility.ToJson(data));
                    fileStream.Close();
                }

                if (Application.platform == RuntimePlatform.WebGLPlayer)
                {
                    SyncFiles();
                }
            }
            catch (Exception e)
            {
                PlatformSafeMessage("Failed to Save: " + e.Message);
            }
        }

        public void Load()
        {
            Debug.Log("Loading data");
            String dataPath = Path.Combine(Application.persistentDataPath, dataDirectoryName + saveFileNumber.value);
            try
            {
                if (Directory.Exists(dataPath))
                {
                    foreach (ScriptableObject data in gameplayData)
                    {
                        String filePath = Path.Combine(dataPath,data.name + ".dat");
                        if (File.Exists(filePath))
                        {
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            FileStream fileStream = File.Open(filePath, FileMode.Open);
                            String jsonData = (String) binaryFormatter.Deserialize(fileStream);
                            JsonUtility.FromJsonOverwrite(jsonData, data);
                            fileStream.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                PlatformSafeMessage("Failed to Load: " + e.Message);
            }
        }

        private static void PlatformSafeMessage(string message)
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                WindowAlert(message);
            }
            else
            {
                Debug.Log(message);
            }
        }
    }
}