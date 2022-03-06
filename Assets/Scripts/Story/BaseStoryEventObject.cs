using System;
using System.Collections.Generic;
using DataStructures.Events;
using UnityEngine;

namespace Story
{
    public abstract class  BaseStoryEventObject : MonoBehaviour
    {
        [SerializeField] internal List<GameEvent> onStartStoryEvents = new List<GameEvent>();
        [SerializeField] internal GameEvent onEndStoryEvent;

        internal abstract void InitializeStoryEvent();
    }
}