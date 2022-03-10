using System;
using System.Collections.Generic;
using MiniGames.InstructionCycle.InstructionCycleUI;
using StateMachine;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleController
{
    public class FetchInstructionState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter " + GetType().FullName);
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