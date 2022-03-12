using System;
using System.Collections.Generic;
using DataStructures.Variables;
using UnityEngine;

namespace Quest
{
    [Serializable]
    [CreateAssetMenu(fileName = "QuestLog", menuName = "Quest/QuestLog", order = 0)]
    public class QuestLog_SO : ScriptableObject
    {
        [SerializeField] private StringListVariable activeQuests;
        [SerializeField] private QuestList_SO questList;

        public List<Quest_SO> GetActiveQuests()
        {
            List<Quest_SO> returnList = new List<Quest_SO>();
            foreach (String questName in activeQuests.value)
            {
                returnList.Add(questList.quests[questName]);
            }

            return returnList;
        }

        public void ActivateQuest(Quest_SO quest)
        {
            if (!activeQuests.value.Contains(quest.QuestName))
            {
                activeQuests.value.Add(quest.QuestName);
            }
            quest.GetCurrentQuestStep().OnFinishTask.RegisterListener(quest.NextStep);
        }

        public void DeactivateQuest(Quest_SO quest)
        {
            if (activeQuests.value.Contains(quest.QuestName))
            {
                activeQuests.value.Remove(quest.QuestName);
            }
        }
    }
}