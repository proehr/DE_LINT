using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameController
{
    public class EndScreenState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(StartScreenState), typeof(ExitingGameState)};
        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}