using System;
using UnityEngine;

namespace Quest
{
    public class QuestController : MonoBehaviour
    {
        [SerializeField] private QuestLog_SO questLog;
        [SerializeField] private QuestList_SO questList;

        private void OnEnable()
        {
            questList.InitQuests();
            
            foreach (Quest_SO quest in questLog.GetActiveQuests())
            {
                quest.GetCurrentQuestStep().OnFinishTask.RegisterListener(quest.NextStep);
            }

            foreach (Quest_SO quest in questList.quests.Values)
            {
                quest.OnStartQuest.RegisterListener(quest.Activate);
            }
        }
        
    }
}