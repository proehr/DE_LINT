using DataStructures.Events;
using UIController;
using UnityEngine;

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

        private void Awake()
        {
            onStartGameplay.RegisterListener(StartGameplay);
            onPause.RegisterListener(PauseGame);
            onResume.RegisterListener(ResumeGame);
            onGameEnd.RegisterListener(EndGame);
            onBackToStartScreen.RegisterListener(BackToStartScreen);
            onExit.RegisterListener(ExitGame);

            InitializeStateMachine(new StartScreenState(startScreenCanvas, saveFilePicker));
        }

        private void StartGameplay()
        {
            TransitionTo(new GameplayState(gameplayController));
        }
        
        private void PauseGame()
        {
            TransitionTo(new PauseScreenState(pauseScreenCanvas));
        }
        
        private void ResumeGame()
        {
            TransitionTo(new GameplayState(gameplayController));
        }
        
        private void EndGame()
        {
            TransitionTo(new EndScreenState());
        }
        
        private void BackToStartScreen()
        {
            TransitionTo(new StartScreenState(startScreenCanvas, saveFilePicker));
        }

        private void ExitGame()
        {
            TransitionTo(new ExitingGameState());
        }
    }
}