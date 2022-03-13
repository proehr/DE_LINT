using System.Collections.Generic;
using DataStructures.Events;
using MiniGames.InstructionCycle.InstructionCycleObjects;
using MiniGames.InstructionCycle.InstructionCycleUI;
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
        [SerializeField] private ArithmeticLogicUnit alu;
        [SerializeField] private HeldValue_SO heldValue;

        [SerializeField] private GameEvent onInsertInstruction;
        [SerializeField] private GameEvent onIncrementProgramCounter;
        [SerializeField] private GameEvent onDecodeInstruction;
        [SerializeField] private GameEvent onFinishExecution;
        [SerializeField] private GameEvent onWriteToMemoryInstructionFinish;
        [SerializeField] private GameEvent onResetInstructionCycle;

        [SerializeField] private InstructionCycleHUDController hudController;

        [SerializeField] private GameEvent onFinishInstructionCycleGame;
        private int instructionCount;
        private int instructionCounter;

        private void Awake()
        {
            InitInstructionCycle();
            onResetInstructionCycle.RegisterListener(InitInstructionCycle);
            onResetInstructionCycle.RegisterListener(ResetValueObjects);
        }

        private void InitInstructionCycle()
        {
            foreach (BaseValue memoryEntry in memoryEntries)
            {
                if (memoryEntry is Instruction)
                {
                    instructionCount++;
                }
            }

            instructionCounter = 0;
            heldValue.SetHeldValue(null);
            memoryBus.memoryEntries = new List<BaseValue>(memoryEntries);
            if (currentStateSO.currentState is IncrementProgramCounterState)
            {
                StartDecodeState();
            }

            if (currentStateSO.currentState is DecodeInstructionTypeState)
            {
                StartExecutionState();
            }

            if (currentStateSO.currentState is ExecuteInstructionState)
            {
                StartFetchInstructionState();
            }

            if (currentStateSO.currentState == null)
            {
                InitializeStateMachine(new FetchInstructionState());
                onInsertInstruction.RegisterListener(StartIncrementState);
                hudController.SetTaskText("Fetch Instruction from memory");
            }
        }

        private void ResetValueObjects()
        {
            foreach (InsertableRegister register in registers)
            {
                register.storedValueObject.ResetValueObject();
                register.InitializeRegister();
            }

            programCounter.storedValueObject.ResetValueObject();
            programCounter.InitializeRegister();
            instructionRegister.storedValueObject.ResetValueObject();
            instructionRegister.InitializeRegister();
            alu.ResetValues();
        }

        private void StartFetchInstructionState()
        {
            if (instructionCounter >= instructionCount)
            {
                onFinishInstructionCycleGame.Raise();
            }

            instructionCounter++;
            onFinishExecution.UnregisterListener(StartFetchInstructionState);
            TransitionTo(new FetchInstructionState());
            onInsertInstruction.RegisterListener(StartIncrementState);
            hudController.SetTaskText("Fetch Instruction from memory");
        }

        private void StartExecutionState()
        {
            onDecodeInstruction.UnregisterListener(StartExecutionState);
            TransitionTo(new ExecuteInstructionState(onFinishExecution,
                (Instruction) instructionRegister.storedValueObject.value, memoryBus, registers,
                onWriteToMemoryInstructionFinish));
            onFinishExecution.RegisterListener(StartFetchInstructionState);
            hudController.SetTaskText("Execute Instruction \n" +
                                      ((Instruction) instructionRegister.storedValueObject.value)
                                      .instructionDescription);
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