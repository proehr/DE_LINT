using System;
using System.Collections.Generic;
using GameController;
using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameplayController
{
    public class ExplorationState : IState
    {
        private GameObject hudCanvas;

        public ExplorationState(GameObject hudCanvas)
        {
            this.hudCanvas = hudCanvas;
        }

        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            hudCanvas.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            hudCanvas.SetActive(false);
        }

        public bool HasNextState(IState nextState)
        {
            return nextState.GetType() == typeof(InteractionState);
        }
    }
}