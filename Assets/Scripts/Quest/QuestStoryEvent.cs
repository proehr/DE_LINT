using Story;
using UnityEngine;

namespace Quest
{
    public class QuestStoryEvent : BaseStoryEventObject
    {
        [SerializeField] private Quest_SO quest;
        [SerializeField] private QuestLog_SO questLog;

        internal override void InitializeStoryEvent()
        {
            questLog.ActivateQuest(quest);
        }
    }
}