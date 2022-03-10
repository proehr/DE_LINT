using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleController
{
    public class IncrementProgramCounterState : IState
    {
        private readonly List<Type> nextStates = new List<Type> {typeof(DecodeInstructionTypeState)};

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