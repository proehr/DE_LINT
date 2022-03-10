using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleController
{
    public class DecodeInstructionTypeState : IState
    {
        private readonly List<Type> nextStates = new List<Type> {typeof(ExecuteInstructionState)};

        public void Enter()
        {
            Debug.Log("Enter " + GetType().FullName);
        }

        public void Exit()
        {
            Debug.Log("Exit " + GetType().FullName);
        }

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}