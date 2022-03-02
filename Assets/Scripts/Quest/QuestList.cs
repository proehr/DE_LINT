using System;
using System.Collections.Generic;

namespace Quest
{
    public static class QuestList
    {
        internal static readonly Dictionary<String, Quest_SO> quests = new Dictionary<String, Quest_SO>();

        public static Quest_SO GetQuest(String name)
        {
            return quests[name];
        }
    }
}