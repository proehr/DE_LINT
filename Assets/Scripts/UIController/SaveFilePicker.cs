using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DataStructures.Events;
using DataStructures.Variables;
using SaveAndLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIController
{
    public class SaveFilePicker : MonoBehaviour
    {
        [SerializeField] private GameEvent onCreateNewGame;
        [SerializeField] private GameEvent onPickSaveFile;
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private IntVariable saveFileNumber;
        [SerializeField] private Button button;

        private List<int> saveFiles;

        private void Awake()
        {
            saveFileNumber.value = 0;
            PreloadSaveFiles();
            onCreateNewGame.RegisterListener(NewSaveFileNumber);
            onPickSaveFile.RegisterListener(SetSaveFileNumber);
        }

        public void PreloadSaveFiles()
        {
            saveFiles = new List<int>();
            dropdown.options = new List<TMP_Dropdown.OptionData>();
            foreach (String directory in Directory.GetDirectories(Application.persistentDataPath))
            {
                if (Path.GetFileName(directory).Contains(SaveAndLoadController.dataDirectoryName))
                {
                    int saveNumber = int.Parse(Regex.Replace(Path.GetFileName(directory), "[^0-9.]", ""));
                    saveFiles.Add(saveNumber);
                    dropdown.options.Add(new TMP_Dropdown.OptionData(saveNumber.ToString()));
                }
            }

            if (saveFiles.Count == 0)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
                dropdown.value = dropdown.options.Count - 1;
            }
        }

        private void NewSaveFileNumber()
        {
            int i = 0;
            while (saveFiles.Contains(i))
            {
                i++;
            }

            saveFileNumber.value = i;
        }

        public void SetSaveFileNumber()
        {
            saveFileNumber.value = int.Parse(dropdown.options[dropdown.value].text);
        }
    }
}