using System;
using DataStructures.Events;
using InputManager;
using MiniGames;
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
        [SerializeField] private GameEvent onStartMiniGame;
        [SerializeField] private GameEvent onEndMiniGame;
        
        // Related Feature Objects
        [SerializeField] private GameObject hudCanvas;
        [SerializeField] private GameObject dialogueCanvas;
        [SerializeField] private PlayerInput explorationInput;
        [SerializeField] private GameplayInputManager inputManager;
        [SerializeField] private QueuedMiniGame_SO queuedMiniGame;
        [SerializeField] private GameObject explorationSpace;
        [SerializeField] private GameObject miniGameSpace;

        private void Awake()
        {
            onStartExploration.RegisterListener(StartExploration);
            onStartDialogue.RegisterListener(StartDialogue);
            onEndDialogue.RegisterListener(StartExploration);
            onStartMiniGame.RegisterListener(StartMiniGame);
            onEndMiniGame.RegisterListener(StartExploration);
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

        private void StartMiniGame()
        {
            TransitionTo(new MiniGameState(queuedMiniGame.miniGameController, explorationSpace, miniGameSpace));
        }
    }
}