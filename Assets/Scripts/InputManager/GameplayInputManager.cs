using DataStructures.Events;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputManager
{
    public class GameplayInputManager : StarterAssetsInputs
    {
        [SerializeField] private GameEvent onPauseGame;
        [SerializeField] private GameEvent onResumeGame;
        [SerializeField] private GameEvent onScrollUp;
        [SerializeField] private GameEvent onScrollDown;
        [SerializeField] private GameEvent onInteract;

        public void OnPauseGame()
        {
            onPauseGame.Raise();
        }

        public void OnResumeGame()
        {
            onResumeGame.Raise();
        }

        public void OnScrollThroughItems(InputValue value)
        {
            float scrollvalue = value.Get<Vector2>().y;
            if (scrollvalue > 0)
            {
                onScrollUp.Raise();
            }else if (scrollvalue < 0)
            {
                onScrollDown.Raise();
            }
        }

        public void OnInteract()
        {
            onInteract.Raise();
        }
        
        public void ResetCursorState()
        {
            Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}