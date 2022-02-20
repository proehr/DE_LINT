using System;
using DataStructures.Events;
using UnityEngine;

namespace GameplayController
{
    internal class GameplayController : StateMachine.StateMachine
    {
        // Incoming Gameplay Events
        [SerializeField] private GameEvent onStartExploration;
        [SerializeField] private GameEvent onStartInteraction;

        private void Awake()
        {
            onStartExploration.RegisterListener(StartExploration);
            onStartInteraction.RegisterListener(StartInteraction);
            
            InitializeStateMachine(new ExplorationState());
        }

        private void StartExploration()
        {
            TransitionTo(new ExplorationState());
        }
        
        private void StartInteraction()
        {
            TransitionTo(new InteractionState());
        }
    }
}