using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "Quest", menuName = "Quest/QuestList", order = 0)]
    public class QuestList_SO : ScriptableObject
    {
        [SerializeField] private List<Quest_SO> questList;
        internal Dictionary<String, Quest_SO> quests = new Dictionary<String, Quest_SO>();

        internal void InitQuests()
        {
            foreach (Quest_SO quest in questList)
            {
                quests.Add(quest.QuestName, quest);
            }
        }

        internal Quest_SO GetQuest(String name)
        {
            return quests[name];
        }
    }
}