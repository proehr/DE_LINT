using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Events;
using DataStructures.Variables;
using InteractionSystem;
using Quest;
using TMPro;
using UnityEngine;

namespace UIController
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text smallLintCountText;
        [SerializeField] private TMP_Text normalLintCountText;
        [SerializeField] private TMP_Text bigLintCountText;

        [SerializeField] private IntVariable smallLintCount;
        [SerializeField] private IntVariable normalLintCount;
        [SerializeField] private IntVariable bigLintCount;
        [SerializeField] private GameEvent onLintCountChanged;
        
        [SerializeField] private GameEvent onChangeInteractableObjects;
        [SerializeField] private InteractableObjects_SO interactableObjects;
        [SerializeField] private GameObject interactionHUD;
        [SerializeField] private Transform interactionListPanel;
        [SerializeField] private TMP_Text activeInteractionNoticePrefab;
        [SerializeField] private TMP_Text interactionNoticePrefab;

        [SerializeField] private GameEvent onTriggerQuestLog;
        [SerializeField] private QuestLog_SO questLog;
        [SerializeField] private GameObject questLogHUD;
        [SerializeField] private Transform questListPanel;
        [SerializeField] private TMP_Text questLogEntryPrefab;
        
        private void Awake()
        {
            onLintCountChanged.RegisterListener(SetLintCountHUDValues);
            onChangeInteractableObjects.RegisterListener(SetInteractableObjects);
            onTriggerQuestLog.RegisterListener(TriggerQuestLog);
            SetLintCountHUDValues();
        }

        private void TriggerQuestLog()
        {
            if (questLogHUD.activeSelf)
            {
                CloseQuestLog();
            }
            else
            {
                OpenQuestLog();
            }
        }

        private void OpenQuestLog()
        {
            foreach (Quest_SO questSo in questLog.GetActiveQuests())
            {
                TMP_Text questLogEntry = Instantiate(questLogEntryPrefab, questListPanel);
                questLogEntry.SetText("- " + questSo.QuestName + ": " + questSo.GetCurrentQuestStep().Description);
            }
            questLogHUD.SetActive(true);
        }
        
        private void CloseQuestLog()
        {
            questLogHUD.SetActive(false);
            for (int i = 0; i < questListPanel.childCount; i++)
            {
                Destroy(questListPanel.GetChild(i).gameObject);
            }
        }

        private void OnEnable()
        {
            SetLintCountHUDValues();
        }

        private void SetLintCountHUDValues()
        {
            smallLintCountText.text = GetStringifiedCount(smallLintCount.value);
            normalLintCountText.text = GetStringifiedCount(normalLintCount.value);
            bigLintCountText.text = GetStringifiedCount(bigLintCount.value);
        }

        private String GetStringifiedCount(int count)
        {
            if (count < 10)
            {
                return "0" + count;
            }

            return count.ToString();
        }

        private void SetInteractableObjects()
        {
            if (!interactableObjects.IOList.Any())
            {
                interactionHUD.SetActive(false);
            }
            else
            {
                interactionHUD.SetActive(true);
                for (int i = 0; i < interactionListPanel.childCount; i++)
                {
                    Destroy(interactionListPanel.GetChild(i).gameObject);
                }
                
                BaseInteractableObject baseInteractableObject = interactableObjects.IOList[0];
                TMP_Text interactableObjectNotice = Instantiate(activeInteractionNoticePrefab, interactionListPanel);
                interactableObjectNotice.SetText(baseInteractableObject.interactionNotice);
                
                for (int i = 1; i < interactableObjects.IOList.Count; i++)
                {
                    baseInteractableObject = interactableObjects.IOList[i];
                    interactableObjectNotice = Instantiate(interactionNoticePrefab, interactionListPanel);
                    interactableObjectNotice.SetText(baseInteractableObject.interactionNotice);
                }
                
                Canvas.ForceUpdateCanvases();
            }
        }
    }
}