using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameController
{
    public class GameplayState : IState
    {

        private readonly GameObject gameplayController;
        private readonly GameObject dialogueController;
        private readonly GameObject environmentSpaces;
        private readonly GameObject storyController;

        public GameplayState(GameObject gameplayController, GameObject dialogueController, GameObject environmentSpaces, GameObject storyController)
        {
            this.gameplayController = gameplayController;
            this.dialogueController = dialogueController;
            this.environmentSpaces = environmentSpaces;
            this.storyController = storyController;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            gameplayController.SetActive(true);
            dialogueController.SetActive(true);
            environmentSpaces.SetActive(true);
            storyController.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            gameplayController.SetActive(false);
            dialogueController.SetActive(false);
            environmentSpaces.SetActive(false);
            storyController.SetActive(false);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(PauseScreenState), typeof(EndScreenState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}