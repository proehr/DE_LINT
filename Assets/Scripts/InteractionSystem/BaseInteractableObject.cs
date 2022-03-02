using System;
using DataStructures.Events;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class BaseInteractableObject : MonoBehaviour
    {
        [SerializeField] public String interactionNotice;

        protected internal abstract void Interact();
    }
}