using System;
using System.Collections.Generic;
using GameController;
using StateMachine;
using UnityEngine;

namespace GameplayController
{
    public class DialogueState : IState

    {
        private readonly GameObject dialogueCanvas;

        public DialogueState(GameObject dialogueCanvas)
        {
            this.dialogueCanvas = dialogueCanvas;
        }

        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            dialogueCanvas.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            dialogueCanvas.SetActive(false);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(DialogueState), typeof(ExplorationState), typeof(MiniGameState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}