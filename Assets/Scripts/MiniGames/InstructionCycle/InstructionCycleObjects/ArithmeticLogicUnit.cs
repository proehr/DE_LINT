using System;
using DataStructures.Events;
using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class ArithmeticLogicUnit : MonoBehaviour
    {
        [SerializeField] private ValueObject valueOne;
        [SerializeField] private ValueObject valueTwo;
        [SerializeField] private ValueObject resultValue;

        [SerializeField] private HeldValue_SO heldValue;
        [SerializeField] private GameEvent onInsertValueOne;
        [SerializeField] private GameEvent onInsertValueTwo;
        [SerializeField] private GameEvent onSumValues;
        [SerializeField] private GameEvent onPickUpResult;

        [SerializeField] private WorldInteractableObject insertValueOneInteractableObject;
        [SerializeField] private WorldInteractableObject insertValueTwoInteractableObject;
        [SerializeField] private WorldInteractableObject calculateSumInteractableObject;
        [SerializeField] private WorldInteractableObject pickUpResultInteractableObject;


        private void Awake()
        {
            DeactivateGameObject(calculateSumInteractableObject.gameObject);
            DeactivateGameObject(pickUpResultInteractableObject.gameObject);
            onInsertValueOne.RegisterListener(SetValueOne);
            onInsertValueTwo.RegisterListener(SetValueTwo);
            onSumValues.RegisterListener(SumValues);
            onPickUpResult.RegisterListener(PickUpResult);
        }

        private void SetValueOne()
        {
            valueOne.SetValue(heldValue.GetHeldValue());
            CheckSummable();
        }

        private void SetValueTwo()
        {
            valueTwo.SetValue(heldValue.GetHeldValue());
            CheckSummable();
        }
        
        public void SumValues()
        {
            DeactivateGameObject(insertValueOneInteractableObject.gameObject);
            DeactivateGameObject(insertValueTwoInteractableObject.gameObject);
            DeactivateGameObject(calculateSumInteractableObject.gameObject);
            BaseValue result = ScriptableObject.CreateInstance<ConstantValue>();
            result.value = valueOne.GetValue().value + valueTwo.GetValue().value;
            result.valueName = result.value.ToString();
            resultValue.SetValue(result);
            valueOne.SetValue(null);
            valueTwo.SetValue(null);
            ActivateGameObject(pickUpResultInteractableObject.gameObject);
        }
        
        private void PickUpResult()
        {
            DeactivateGameObject(pickUpResultInteractableObject.gameObject);
            heldValue.SetHeldValue((TransportableValue)resultValue.GetValue());
            ActivateGameObject(insertValueOneInteractableObject.gameObject);
            ActivateGameObject(insertValueTwoInteractableObject.gameObject);
        }

        private void CheckSummable()
        {
            if (valueOne.GetValue() != null && valueTwo.GetValue() != null)
            {
                ActivateGameObject(calculateSumInteractableObject.gameObject);
            }
            else
            {
                DeactivateGameObject(calculateSumInteractableObject.gameObject);
            }
        }

        private void ActivateGameObject(GameObject go)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
            }
        }

        private void DeactivateGameObject(GameObject go)
        {
            if (go.activeSelf)
            {
                go.SetActive(false);
            }
        }
    }
}