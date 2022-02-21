using System;
using System.Collections.Generic;
using StateMachine;
using UIController;
using UnityEngine;

namespace GameController
{
    public class StartScreenState : IState
    {
        private readonly GameObject startScreenCanvas;
        private readonly SaveFilePicker saveFilePicker;

        public StartScreenState(GameObject startScreenCanvas, SaveFilePicker saveFilePicker)
        {
            this.startScreenCanvas = startScreenCanvas;
            this.saveFilePicker = saveFilePicker;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            startScreenCanvas.SetActive(true);
            saveFilePicker.PreloadSaveFiles();
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            startScreenCanvas.SetActive(false);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(GameplayState), typeof(ExitingGameState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}