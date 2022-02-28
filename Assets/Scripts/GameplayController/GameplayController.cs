using System;
using DataStructures.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameplayController
{
    internal class GameplayController : StateMachine.StateMachine
    {
        // Incoming Gameplay Events
        [SerializeField] private GameEvent onStartExploration;
        [SerializeField] private GameEvent onStartInteraction;
        
        // Related Feature Objects
        [SerializeField] private GameObject hudCanvas;

        private void Awake()
        {
            onStartExploration.RegisterListener(StartExploration);
            onStartInteraction.RegisterListener(StartInteraction);
        }

        private void OnEnable()
        {
            InitializeStateMachine(new ExplorationState(hudCanvas));
        }

        private void StartExploration()
        {
            TransitionTo(new ExplorationState(hudCanvas));
        }
        
        private void StartInteraction()
        {
            TransitionTo(new InteractionState());
        }
    }
}