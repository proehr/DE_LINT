using System;
using System.Collections.Generic;
using MiniGames;
using StateMachine;
using UnityEngine;

namespace GameplayController
{
    public class MiniGameState : IState
    {
        private BaseMiniGameController miniGameController;
        private GameObject explorationSpace;
        private GameObject miniGameSpace;

        public MiniGameState(BaseMiniGameController miniGameController, GameObject explorationSpace,
            GameObject miniGameSpace)
        {
            this.miniGameController = miniGameController;
            this.explorationSpace = explorationSpace;
            this.miniGameSpace = miniGameSpace;
        }

        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            explorationSpace.SetActive(false);
            miniGameSpace.SetActive(true);
            miniGameController.gameObject.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            miniGameController.gameObject.SetActive(false);
            miniGameSpace.SetActive(false);
            explorationSpace.SetActive(true);
        }

        private readonly List<Type> nextStates = new List<Type>
            {typeof(DialogueState), typeof(ExplorationState), typeof(MiniGameState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}