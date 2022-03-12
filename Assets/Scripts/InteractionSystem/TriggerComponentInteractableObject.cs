using System;
using System.Collections.Generic;
using DataStructures.Events;
using DataStructures.Variables;
using UnityEngine;

namespace InteractionSystem
{
    public class TriggerComponentInteractableObject : BaseInteractableObject
    {
        [SerializeField] private List<GameObject> removableComponents;
        [SerializeField] private String removeInteractionNotice;
        [SerializeField] private String enableInteractionNotice;
        [SerializeField] private BoolVariable isComponentActive;
        [SerializeField] private GameEvent onChangeInteractables;

        private void Awake()
        {
            SetInteractionNotice();
            SetGameObjectsActive(isComponentActive.value);
        }

        private void SetInteractionNotice()
        {
            if (isComponentActive.value)
            {
                interactionNotice = removeInteractionNotice;
            }
            else
            {
                interactionNotice = enableInteractionNotice;
            }
        }

        protected internal override void Interact()
        {
            base.Interact();
            isComponentActive.value = !isComponentActive.value;
            SetInteractionNotice();
            onChangeInteractables.Raise();
            SetGameObjectsActive(isComponentActive.value);
        }

        private void SetGameObjectsActive(bool componentActive)
        {
            foreach (GameObject component in removableComponents)
            {
                component.SetActive(componentActive);
            }
        }
    }
}