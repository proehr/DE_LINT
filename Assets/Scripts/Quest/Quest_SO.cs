using System;
using System.Collections.Generic;
using DataStructures.Events;
using DataStructures.Variables;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest", order = 0)]
    public class Quest_SO : ScriptableObject
    {
        [SerializeField] private String questName;
        [SerializeField] private GameEvent onStartQuest;
        [SerializeField] private List<QuestTask_SO> questSteps = new List<QuestTask_SO>();
        
        [SerializeField] private IntVariable currentQuestStep;
        [SerializeField] private QuestLog_SO questLog;
        [SerializeField] private QuestList_SO questList;

        public string QuestName => questName;

        internal GameEvent OnStartQuest => onStartQuest;

        public QuestTask_SO GetCurrentQuestStep()
        {
            return questSteps[currentQuestStep.value];
        }

        public void NextStep()
        {
            currentQuestStep.value++;
            if (currentQuestStep.value < questSteps.Count)
            {
                questSteps[currentQuestStep.value].OnFinishTask.RegisterListener(NextStep);
            }
            else
            {
                Deactivate();
            }
        }

        public void Activate()
        {
            Debug.Log("Activate quest " + questName);
            questLog.ActivateQuest(this);
        }

        public void Deactivate()
        {
            Debug.Log("Deactivate quest " + questName);
            questLog.DeactivateQuest(this);
        }
    }
}