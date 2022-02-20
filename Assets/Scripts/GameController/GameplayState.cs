using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameController
{
    public class GameplayState : IState
    {

        private readonly GameObject gameplayController;
        
        public GameplayState(GameObject gameplayController)
        {
            this.gameplayController = gameplayController;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            gameplayController.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            gameplayController.SetActive(false);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(PauseScreenState), typeof(EndScreenState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}