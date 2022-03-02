using System;
using DataStructures.Events;
using InputManager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameplayController
{
    internal class GameplayController : StateMachine.StateMachine
    {
        // Incoming Gameplay Events
        [SerializeField] private GameEvent onStartExploration;
        [SerializeField] private GameEvent onStartDialogue;
        [SerializeField] private GameEvent onEndDialogue;
        
        // Related Feature Objects
        [SerializeField] private GameObject hudCanvas;
        [SerializeField] private GameObject dialogueCanvas;
        [SerializeField] private PlayerInput explorationInput;
        [SerializeField] private GameplayInputManager inputManager;

        private void Awake()
        {
            onStartExploration.RegisterListener(StartExploration);
            onStartDialogue.RegisterListener(StartDialogue);
            onEndDialogue.RegisterListener(StartExploration);
        }

        private void OnEnable()
        {
            InitializeStateMachine(new ExplorationState(hudCanvas, explorationInput, inputManager));
        }

        private void StartExploration()
        {
            TransitionTo(new ExplorationState(hudCanvas, explorationInput, inputManager));
        }
        
        private void StartDialogue()
        {
            TransitionTo(new DialogueState(dialogueCanvas));
        }
    }
}