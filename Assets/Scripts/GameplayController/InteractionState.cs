using System;
using System.Collections.Generic;
using GameController;
using StateMachine;
using UnityEngine;

namespace GameplayController
{
    public class InteractionState : IState

    {
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(InteractionState), typeof(ExplorationState)};
        
        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}