using DataStructures.Events;
using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class InstructionRegister : InsertableRegister
    {
        [SerializeField] private DecodeInstructionInteractableObject decodeInstructionInteraction;
        [SerializeField] private GameEvent onIncrementProgramCounter;
        [SerializeField] private GameEvent onInsertInstruction;
        [SerializeField] private GameEvent onDecodeInstruction;

        [SerializeField] internal ValueObject instructionNameValueObject;
        [SerializeField] internal ValueObject firstParameterValueObject;
        [SerializeField] internal ValueObject secondParameterValueObject;

        internal override void InitializeRegister()
        {
            DeactivateDecodeInteraction();
            DeactivateGameObject(instructionNameValueObject.gameObject);
            DeactivateGameObject(firstParameterValueObject.gameObject);
            DeactivateGameObject(secondParameterValueObject.gameObject);
            onIncrementProgramCounter.RegisterListener(ActivateDecodeInteraction);
            onInsertInstruction.RegisterListener(DeactivateDecodedInstructionInfo);
            onDecodeInstruction.RegisterListener(DeactivateDecodeInteraction);
            onDecodeInstruction.RegisterListener(ActivateDecodedInstructionInfo);
            onDecodeInstruction.RegisterListener(DisableInsertInteraction);
            base.InitializeRegister();
        }
        

        private void ActivateDecodeInteraction()
        {
            decodeInstructionInteraction.gameObject.SetActive(true);
        }

        private void DeactivateDecodeInteraction()
        {
            decodeInstructionInteraction.gameObject.SetActive(false);
        }
        
        private void ActivateDecodedInstructionInfo()
        {
            DeactivateGameObject(storedValueObject.gameObject);
            ActivateGameObject(instructionNameValueObject.gameObject);
            ActivateGameObject(firstParameterValueObject.gameObject);
            ActivateGameObject(secondParameterValueObject.gameObject);
        }

        private void DeactivateDecodedInstructionInfo()
        {
            ActivateGameObject(storedValueObject.gameObject);
            DeactivateGameObject(instructionNameValueObject.gameObject);
            DeactivateGameObject(firstParameterValueObject.gameObject);
            DeactivateGameObject(secondParameterValueObject.gameObject);
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