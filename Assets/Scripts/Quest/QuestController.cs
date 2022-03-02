using System;
using UnityEngine;

namespace Quest
{
    public class QuestController : MonoBehaviour
    {
        [SerializeField] private QuestLog_SO questLog;

        private void OnEnable()
        {
            foreach (Quest_SO quest in questLog.GetActiveQuests())
            {
                quest.GetCurrentQuestStep().OnFinishTask.RegisterListener(quest.NextStep);
            }

            foreach (Quest_SO quest in QuestList.quests.Values)
            {
                quest.OnStartQuest.RegisterListener(quest.Activate);
            }
        }
        
    }
}