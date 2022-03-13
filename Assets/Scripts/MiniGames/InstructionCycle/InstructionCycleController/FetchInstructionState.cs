using System;
using System.Collections.Generic;
using MiniGames.InstructionCycle.InstructionCycleObjects;
using MiniGames.InstructionCycle.InstructionCycleUI;
using StateMachine;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleController
{
    public class FetchInstructionState : IState
    {
        private Instruction currentInstruction;
        private InstructionRegister instructionRegister;

        public FetchInstructionState(Instruction currentInstruction, InstructionRegister instructionRegister)
        {
            this.currentInstruction = currentInstruction;
            this.instructionRegister = instructionRegister;
        }

        public void Enter()
        {
            Debug.Log("Enter " + GetType().FullName);
            instructionRegister.SetTargetValue(currentInstruction.GetType(), currentInstruction.value);
        }

        public void Exit()
        {
            Debug.Log("Exit " + GetType().FullName);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(IncrementProgramCounterState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}