using System;
using DataStructures.Events;
using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class DecodeInstructionInteractableObject : BaseInteractableObject
    {
        [SerializeField] private InstructionRegister register;
        [SerializeField] private GameEvent onWriteToMemoryInstructionDecode;

        protected internal override void Interact()
        {
            base.Interact();
            register.instructionNameValueObject.SetValue(((Instruction) register.storedValueObject.GetValue()).instructionName);
            register.firstParameterValueObject.SetValue(((Instruction) register.storedValueObject.GetValue()).parameterOne);
            register.secondParameterValueObject.SetValue(((Instruction) register.storedValueObject.GetValue()).parameterTwo);
            register.storedValueObject.SetValue(((Instruction) register.storedValueObject.GetValue()).GetTransportableValue());
            if (register.firstParameterValueObject.value is MemoryAddress)
            {
                onWriteToMemoryInstructionDecode.Raise();
                register.pickUpValueInteraction.gameObject.SetActive(false);
            }
        }
    }
}