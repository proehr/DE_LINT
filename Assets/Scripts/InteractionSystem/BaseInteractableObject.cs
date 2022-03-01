using System;
using DataStructures.Events;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class BaseInteractableObject : MonoBehaviour
    {
        [SerializeField] private GameEvent onInteract;
        [SerializeField] public String interactionNotice;

        private void Awake()
        {
            onInteract.RegisterListener(Interact);
        }

        protected internal abstract void Interact();
    }
}