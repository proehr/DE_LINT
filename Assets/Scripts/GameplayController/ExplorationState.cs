using System;
using System.Collections.Generic;
using GameController;
using StateMachine;
using UnityEngine;

namespace GameplayController
{
    public class ExplorationState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
        }

        public bool HasNextState(IState nextState)
        {
            return nextState.GetType() == typeof(InteractionState);
        }
    }
}