using System;
using DataStructures.Events;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class InsertableRegister : Register
    {
        [SerializeField] internal InsertValueInteractableObject insertValueInteraction;
        [SerializeField] internal GameEvent onPickUpValue;
        [SerializeField] internal GameEvent onDropValue;
        [SerializeField] internal HeldValue_SO heldValue;
        private Type targetValueType;
        private int targetValue;


        internal override void InitializeRegister()
        {
            DisableInsertInteraction();
            base.InitializeRegister();
        }

        public void SetTargetValue(Type valueType, int i)
        {
            targetValueType = valueType;
            targetValue = i;
            if (valueType != null)
            {
                onPickUpValue.RegisterListener(CheckForTargetValue);
                onDropValue.RegisterListener(CheckForTargetValue);
            }
            else
            {
                onPickUpValue.UnregisterListener(CheckForTargetValue);
                onDropValue.UnregisterListener(CheckForTargetValue);
            }
        }

        private void CheckForTargetValue()
        {
            if (heldValue.GetHeldValue() != null &&
                heldValue.GetHeldValue().GetType() == targetValueType &&
                heldValue.GetHeldValue().value == targetValue)
            {
                EnableInsertInteraction();
            }
            else
            {
                DisableInsertInteraction();
            }
        }


        private void EnableInsertInteraction()
        {
            if (!insertValueInteraction.gameObject.activeSelf)
            {
                insertValueInteraction.gameObject.SetActive(true);
            }
        }

        internal void DisableInsertInteraction()
        {
            if (insertValueInteraction.gameObject.activeSelf)
            {
                insertValueInteraction.gameObject.SetActive(false);
            }
        }

        public void SetStoredValue(BaseValue v)
        {
            storedValueObject.SetValue(v);
            if (storedValueObject.value != null)
            {
                pickUpValueInteraction.gameObject.SetActive(true);
            }

            if (v.GetType() == targetValueType && v.value == targetValue)
            {
                SetTargetValue(null, 0);
            }
            
            DisableInsertInteraction();
        }
    }
}