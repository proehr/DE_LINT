using System;
using System.Collections.Generic;
using DataStructures.Events;
using DataStructures.Variables;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class BaseInteractableObject : MonoBehaviour
    {
        [SerializeField] public String interactionNotice;
        [SerializeField] public List<GameEvent> onInteractionEvents;
        [SerializeField] private bool onceInteractable;
        
        // Remember to set this to true! And is only needed if onceInteractable
        [SerializeField] private BoolVariable isActive;

        protected internal virtual void Interact()
        {
            foreach (GameEvent interactionEvent in onInteractionEvents)
            {
                interactionEvent.Raise();
            }

            if (onceInteractable)
            {
                isActive.value = false;
                gameObject.SetActive(false);
            }
        }
    }
}