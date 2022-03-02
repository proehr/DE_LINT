using System;
using System.Collections.Generic;
using GameController;
using InputManager;
using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameplayController
{
    public class ExplorationState : IState
    {
        private GameObject hudCanvas;
        private PlayerInput explorationInput;
        private GameplayInputManager gameplayInputManager;

        public ExplorationState(GameObject hudCanvas, PlayerInput explorationInput,
            GameplayInputManager gameplayInputManager)
        {
            this.hudCanvas = hudCanvas;
            this.explorationInput = explorationInput;
            this.gameplayInputManager = gameplayInputManager;
        }

        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            hudCanvas.SetActive(true);
            explorationInput.ActivateInput();
            gameplayInputManager.cursorLocked = true;
            gameplayInputManager.cursorInputForLook = true;
            gameplayInputManager.ResetCursorState();
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            hudCanvas.SetActive(false);
            explorationInput.DeactivateInput();
            gameplayInputManager.cursorLocked = false;
            gameplayInputManager.cursorInputForLook = false;
            gameplayInputManager.ResetCursorState();
        }

        public bool HasNextState(IState nextState)
        {
            return nextState.GetType() == typeof(DialogueState);
        }
    }
}