using DataStructures.Events;
using StarterAssets;
using UnityEngine;

namespace InputManager
{
    public class GameplayInputManager : StarterAssetsInputs
    {
        [SerializeField] private GameEvent onPauseGame;
        [SerializeField] private GameEvent onResumeGame;

        public void OnPauseGame()
        {
            onPauseGame.Raise();
        }

        public void OnResumeGame()
        {
            onResumeGame.Raise();
        }
    }
}