using System;
using System.Collections.Generic;
using DataStructures.Events;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class MemoryBus : MonoBehaviour
    {
        [SerializeField] internal List<BaseValue> memoryEntries;
        [SerializeField] private InstructionRegister instructionRegister;
        [SerializeField] private GetFromMemoryInteractableObject getFromMemoryInteractableObject;
        [SerializeField] internal WriteToMemoryInteractableObject writeToMemoryInteractableObject;
        [SerializeField] private GameEvent onPickUpMemoryAddress;
        [SerializeField] private GameEvent onDropMemoryAddress;
        [SerializeField] private GameEvent onWriteToMemoryInstructionDecode;
        [SerializeField] private GameEvent onWriteToMemoryInstructionFinish;

        private void Awake()
        {
            DeactivateGetFromMemory();
            DeactivateWriteToMemory();
            onPickUpMemoryAddress.RegisterListener(ActivateGetFromMemory);
            onDropMemoryAddress.RegisterListener(DeactivateGetFromMemory);
            onWriteToMemoryInstructionDecode.RegisterListener(ActivateWriteToMemory);
            onWriteToMemoryInstructionFinish.RegisterListener(DeactivateWriteToMemory);
        }

        private void ActivateGetFromMemory()
        {
            getFromMemoryInteractableObject.gameObject.SetActive(true);
        }

        private void DeactivateGetFromMemory()
        {
            getFromMemoryInteractableObject.gameObject.SetActive(false);
        }

        private void ActivateWriteToMemory()
        {
            writeToMemoryInteractableObject.gameObject.SetActive(true);
        }
        
        private void DeactivateWriteToMemory()
        {
            writeToMemoryInteractableObject.gameObject.SetActive(false);
        }

        internal TransportableValue GetFromMemory(MemoryAddress memoryAddress)
        {
            return (TransportableValue)memoryEntries[memoryAddress.value];
        }
        
        public void WriteValue(TransportableValue heldValue)
        {
            memoryEntries[instructionRegister.firstParameterValueObject.value.value] = heldValue;
        }

        public int GetNextInstructionAddressValue(int currentValue)
        {
            for (int i = currentValue + 1; i < memoryEntries.Count; i++)
            {
                if (memoryEntries[i] is Instruction)
                {
                    return i;
                }
            }

            for (int i = 0; i < currentValue; i++)
            {
                if (memoryEntries[i] is Instruction)
                {
                    return i;
                }
            }

            return currentValue;
        }
    }
}