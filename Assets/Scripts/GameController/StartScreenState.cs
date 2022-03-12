using System;
using System.Collections.Generic;
using Environment;
using StateMachine;
using UIController;
using UnityEngine;

namespace GameController
{
    public class StartScreenState : IState
    {
        private readonly GameObject startScreenCanvas;
        private readonly SaveFilePicker saveFilePicker;
        
        private readonly GameObject gameplayController;
        private readonly GameObject dialogueController;
        private readonly EnvironmentSpaces environmentSpaces;
        private readonly GameObject storyController;

        public StartScreenState(GameObject startScreenCanvas, SaveFilePicker saveFilePicker, GameObject gameplayController, GameObject dialogueController, EnvironmentSpaces environmentSpaces, GameObject storyController)
        {
            this.startScreenCanvas = startScreenCanvas;
            this.saveFilePicker = saveFilePicker;
            this.gameplayController = gameplayController;
            this.dialogueController = dialogueController;
            this.environmentSpaces = environmentSpaces;
            this.storyController = storyController;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            startScreenCanvas.SetActive(true);
            saveFilePicker.PreloadSaveFiles();
            gameplayController.SetActive(false);
            dialogueController.SetActive(false);
            environmentSpaces.gameObject.SetActive(false);
            storyController.SetActive(false);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            startScreenCanvas.SetActive(false);
            gameplayController.SetActive(true);
            dialogueController.SetActive(true);
            environmentSpaces.gameObject.SetActive(true);
            storyController.SetActive(true);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(GameplayState), typeof(ExitingGameState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}