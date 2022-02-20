using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameController
{
    public class GameplayState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(PauseScreenState), typeof(EndScreenState)};
        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}