using System;
using System.Collections.Generic;
using Environment;
using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameController
{
    public class GameplayState : IState
    {
        private readonly EnvironmentSpaces environmentSpaces;

        public GameplayState(EnvironmentSpaces environmentSpaces)
        {
            this.environmentSpaces = environmentSpaces;
        }

        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            if (environmentSpaces.spaces[environmentSpaces.currentSpace.value] is ThirdPersonEnvironmentSpace
                thirdPersonEnvironmentSpace)
            {
                thirdPersonEnvironmentSpace.ActivateThirdPersonInput();
            }
        }

        public void Exit()
        {
            if (environmentSpaces.spaces[environmentSpaces.currentSpace.value] is ThirdPersonEnvironmentSpace
                thirdPersonEnvironmentSpace)
            {
                thirdPersonEnvironmentSpace.DeactivateThirdPersonInput();
            }
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(PauseScreenState), typeof(EndScreenState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}