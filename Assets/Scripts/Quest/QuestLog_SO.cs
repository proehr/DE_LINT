using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    [Serializable]
    [CreateAssetMenu(fileName = "QuestLog", menuName = "Quest/QuestLog", order = 0)]
    public class QuestLog_SO : ScriptableObject
    {
        [SerializeField] private List<String> activeQuests = new List<String>();

        public List<Quest_SO> GetActiveQuests()
        {
            List<Quest_SO> returnList = new List<Quest_SO>();
            foreach (String name in activeQuests)
            {
                returnList.Add(QuestList.quests[name]);
            }

            return returnList;
        }

        public void ActivateQuest(Quest_SO quest)
        {
            if (!activeQuests.Contains(quest.QuestName))
            {
                activeQuests.Add(quest.QuestName);
            }
            quest.GetCurrentQuestStep().OnFinishTask.RegisterListener(quest.NextStep);
        }

        public void DeactivateQuest(Quest_SO quest)
        {
            if (activeQuests.Contains(quest.QuestName))
            {
                activeQuests.Remove(quest.QuestName);
            }
        }
    }
}