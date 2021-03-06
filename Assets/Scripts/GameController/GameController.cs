using DataStructures.Events;
using Environment;
using UIController;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameController
{
    internal class GameController : StateMachine.StateMachine
    {
        
        // Incoming game events
        [SerializeField] private GameEvent onStartGameplay;
        [SerializeField] private GameEvent onPause;
        [SerializeField] private GameEvent onResume;
        [SerializeField] private GameEvent onGameEnd;
        [SerializeField] private GameEvent onBackToStartScreen;
        [SerializeField] private GameEvent onExit;
        
        // Features
        [SerializeField] private GameObject startScreenCanvas;
        [SerializeField] private SaveFilePicker saveFilePicker;
        [SerializeField] private GameObject pauseScreenCanvas;
        [SerializeField] private GameObject gameplayController;
        [SerializeField] private EnvironmentSpaces environmentSpaces;

        private void Awake()
        {
            onStartGameplay.RegisterListener(StartGameplay);
            onPause.RegisterListener(PauseGame);
            onResume.RegisterListener(ResumeGame);
            onGameEnd.RegisterListener(EndGame);
            onBackToStartScreen.RegisterListener(BackToStartScreen);
            onExit.RegisterListener(ExitGame); ;

            InitializeStateMachine(new StartScreenState(startScreenCanvas, saveFilePicker, gameplayController));
        }

        private void StartGameplay()
        {
            TransitionTo(new GameplayState(environmentSpaces));
        }
        
        private void PauseGame()
        {
            TransitionTo(new PauseScreenState(pauseScreenCanvas));
        }
        
        private void ResumeGame()
        {
            TransitionTo(new GameplayState(environmentSpaces));
        }
        
        private void EndGame()
        {
            TransitionTo(new EndScreenState());
        }
        
        private void BackToStartScreen()
        {
            TransitionTo(new StartScreenState(startScreenCanvas, saveFilePicker, gameplayController));
        }

        private void ExitGame()
        {
            TransitionTo(new ExitingGameState());
        }
    }
}