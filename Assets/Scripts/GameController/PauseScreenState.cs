using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameController
{
    public class PauseScreenState : IState
    {

        private readonly GameObject pauseScreenCanvas;

        public PauseScreenState(GameObject pauseScreenCanvas)
        {
            this.pauseScreenCanvas = pauseScreenCanvas;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            pauseScreenCanvas.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            pauseScreenCanvas.SetActive(false);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(GameplayState), typeof(StartScreenState), typeof(ExitingGameState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}