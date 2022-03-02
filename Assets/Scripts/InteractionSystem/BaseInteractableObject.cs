using System;
using System.Collections.Generic;
using DataStructures.Events;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class BaseInteractableObject : MonoBehaviour
    {
        [SerializeField] public String interactionNotice;
        [SerializeField] public List<GameEvent> onInteractionEvents;

        protected internal virtual void Interact()
        {
            foreach (GameEvent interactionEvent in onInteractionEvents)
            {
                interactionEvent.Raise();
            }
        }
    }
}