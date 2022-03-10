using System;
using System.Collections.Generic;
using DataStructures.Events;
using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class Register : MonoBehaviour
    {
        [SerializeField] internal PickUpInteractableObject pickUpValueInteraction;

        [SerializeField] internal ValueObject storedValueObject;

        internal void Awake()
        {
            InitializeRegister();
        }

        internal virtual void InitializeRegister()
        {
            if (storedValueObject != null)
            {
                pickUpValueInteraction.gameObject.SetActive(true);
            }
            else
            {
                pickUpValueInteraction.gameObject.SetActive(false);
            }
        }

        public void SetStoredValue(BaseValue value)
        {
            if (storedValueObject != null && value != null)
            {
                pickUpValueInteraction.gameObject.SetActive(true);
            }
            storedValueObject.SetValue(value);
        }
    }
}