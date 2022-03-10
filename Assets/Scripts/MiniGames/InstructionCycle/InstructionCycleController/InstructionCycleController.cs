using System;
using System.Collections.Generic;
using DataStructures.Events;
using MiniGames.InstructionCycle.InstructionCycleObjects;
using MiniGames.InstructionCycle.InstructionCycleUI;
using StateMachine;
using TMPro;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleController
{
    internal class InstructionCycleController : StateMachine.StateMachine
    {
        [SerializeField] private InstructionRegister instructionRegister;
        [SerializeField] private ProgramCounter programCounter;
        [SerializeField] private MemoryBus memoryBus;
        [SerializeField] private List<BaseValue> memoryEntries;
        [SerializeField] private List<InsertableRegister> registers;
        [SerializeField] private HeldValue_SO heldValue;
        
        [SerializeField] private GameEvent onInsertInstruction;
        [SerializeField] private GameEvent onIncrementProgramCounter;
        [SerializeField] private GameEvent onDecodeInstruction;
        [SerializeField] private GameEvent onFinishExecution;
        [SerializeField] private GameEvent onWriteToMemoryInstructionFinish;

        [SerializeField] private InstructionCycleHUDController hudController;

        private void Awake()
        {
            heldValue.SetHeldValue(null);
            memoryBus.memoryEntries = new List<BaseValue>(memoryEntries);
            InitializeStateMachine(new FetchInstructionState());
            onInsertInstruction.RegisterListener(StartIncrementState);
            hudController.SetTaskText("Fetch Instruction from memory");
        }

        private void StartFetchInstructionState()
        {
            onFinishExecution.UnregisterListener(StartFetchInstructionState);
            TransitionTo(new FetchInstructionState());
            onInsertInstruction.RegisterListener(StartIncrementState);
            hudController.SetTaskText("Fetch Instruction from memory");
        }

        private void StartExecutionState()
        {
            onDecodeInstruction.UnregisterListener(StartExecutionState);
            TransitionTo(new ExecuteInstructionState(onFinishExecution, (Instruction)instructionRegister.storedValueObject.value, memoryBus, registers, onWriteToMemoryInstructionFinish));
            onFinishExecution.RegisterListener(StartFetchInstructionState);
            hudController.SetTaskText("Execute Instruction \n" + ((Instruction)instructionRegister.storedValueObject.value).instructionDescription);
        }

        private void StartDecodeState()
        {
            onIncrementProgramCounter.UnregisterListener(StartDecodeState);
            TransitionTo(new DecodeInstructionTypeState());
            onDecodeInstruction.RegisterListener(StartExecutionState);
            hudController.SetTaskText("Decode Instruction in Instruction Register");
        }

        private void StartIncrementState()
        {
            onInsertInstruction.UnregisterListener(StartIncrementState);
            TransitionTo(new IncrementProgramCounterState());
            onIncrementProgramCounter.RegisterListener(StartDecodeState);
            hudController.SetTaskText("Increment Program Counter");
        }
    }
}