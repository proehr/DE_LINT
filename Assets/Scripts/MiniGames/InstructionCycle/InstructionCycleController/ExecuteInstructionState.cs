using System;
using System.Collections.Generic;
using DataStructures.Events;
using MiniGames.InstructionCycle.InstructionCycleObjects;
using StateMachine;
using UnityEngine;
using Object = System.Object;

namespace MiniGames.InstructionCycle.InstructionCycleController
{
    public class ExecuteInstructionState : IState
    {
        private readonly GameEvent onFinishExecution;
        private readonly Instruction instruction;
        private readonly MemoryBus memoryBus;
        private readonly List<InsertableRegister> registers;
        private readonly GameEvent onWriteToMemoryInstructionFinish;

        private GameEvent onChangeTargetValue;
        private BaseValue targetAddress;
        private int targetValue;
        private Type targetValueType;

        public ExecuteInstructionState(GameEvent onFinishExecution, Instruction instruction, MemoryBus memoryBus,
            List<InsertableRegister> registers, GameEvent onWriteToMemoryInstructionFinish)
        {
            this.onFinishExecution = onFinishExecution;
            this.instruction = instruction;
            this.memoryBus = memoryBus;
            this.registers = registers;
            this.onWriteToMemoryInstructionFinish = onWriteToMemoryInstructionFinish;
        }

        public void Enter()
        {
            Debug.Log("Enter " + GetType().FullName);

            switch (instruction.type)
            {
                case InstructionType.MOV:
                    SetTargetsMov();
                    break;
                case InstructionType.ADD:
                    SetTargetsAdd();
                    break;
            }

            targetAddress = instruction.parameterOne;

            onChangeTargetValue = ScriptableObject.CreateInstance<GameEvent>();
            onChangeTargetValue.RegisterListener(CheckForTargetReached);

            if (instruction.parameterOne is MemoryAddress)
            {
                memoryBus.writeToMemoryInteractableObject.onInteractionEvents.Add(onChangeTargetValue);
            }
            else if (instruction.parameterOne is RegisterAddress)
            {
                registers[instruction.parameterOne.value].insertValueInteraction.onInteractionEvents
                    .Add(onChangeTargetValue);
            }
        }

        private void CheckForTargetReached()
        {
            bool targetReached = false;
            switch (targetAddress)
            {
                case MemoryAddress memoryAddress:
                    targetReached = EqualsTargetValue(memoryBus.GetFromMemory(memoryAddress));
                    break;
                case RegisterAddress registerAddress:
                    targetReached = EqualsTargetValue(registers[registerAddress.value].storedValueObject.value);
                    break;
            }

            if (targetReached)
            {
                onChangeTargetValue.UnregisterListener(CheckForTargetReached);
                onFinishExecution.Raise();
            }
        }

        private bool EqualsTargetValue(BaseValue comparisonValue)
        {
            return comparisonValue.GetType() == targetValueType && comparisonValue.value == targetValue;
        }

        private void SetTargetsAdd()
        {
            targetValueType = typeof(ConstantValue);
            int summand = 0;
            if (instruction.parameterTwo is ConstantValue)
            {
                summand = instruction.parameterTwo.value;
            }
            else if (instruction.parameterTwo is MemoryAddress)
            {
                summand = memoryBus.GetFromMemory((MemoryAddress) instruction.parameterTwo).value;
            }
            else if (instruction.parameterTwo is RegisterAddress)
            {
                summand = registers[instruction.parameterTwo.value].storedValueObject.value.value;
            }

            if (instruction.parameterOne is MemoryAddress)
            {
                targetValue = summand + memoryBus.GetFromMemory((MemoryAddress) instruction.parameterOne).value;
            }
            else if (instruction.parameterOne is RegisterAddress)
            {
                targetValue = summand + registers[instruction.parameterOne.value].storedValueObject.value.value;
            }
        }

        private void SetTargetsMov()
        {
            if (instruction.parameterTwo is ConstantValue)
            {
                targetValueType = typeof(ConstantValue);
                targetValue = instruction.parameterTwo.value;
            }
            else if (instruction.parameterTwo is MemoryAddress)
            {
                targetValueType = memoryBus.GetFromMemory((MemoryAddress) instruction.parameterTwo).GetType();
                targetValue = memoryBus.GetFromMemory((MemoryAddress) instruction.parameterTwo).value;
            }
            else if (instruction.parameterTwo is RegisterAddress)
            {
                targetValueType = registers[instruction.parameterTwo.value].storedValueObject.value.GetType();
                targetValue = registers[instruction.parameterTwo.value].storedValueObject.value.value;
            }
        }

        public void Exit()
        {
            Debug.Log("Exit " + GetType().FullName);
            if (instruction.parameterOne is MemoryAddress)
            {
                onWriteToMemoryInstructionFinish.Raise();
            }

            // TODO coroutine to remove onChangeTargetValue event from target
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(FetchInstructionState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}