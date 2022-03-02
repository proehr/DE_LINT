using System;
using DataStructures.Events;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "QuestTask", menuName = "Quest/QuestTask", order = 0)]
    public class QuestTask_SO : ScriptableObject
    {
        [SerializeField] private String description;
        [SerializeField] private GameEvent onFinishTask;

        public string Description => description;

        internal GameEvent OnFinishTask => onFinishTask;
    }
}