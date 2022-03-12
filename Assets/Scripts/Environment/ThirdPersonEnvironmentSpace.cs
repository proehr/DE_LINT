using InputManager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Environment
{
    public class ThirdPersonEnvironmentSpace : EnvironmentSpace
    {
        [SerializeField] private PlayerInput thirdPersonInput;
        [SerializeField] private GameplayInputManager gameplayInputManager;

        internal void DeactivateThirdPersonInput()
        {
            thirdPersonInput.DeactivateInput();
            gameplayInputManager.cursorLocked = false;
            gameplayInputManager.cursorInputForLook = false;
            gameplayInputManager.ResetCursorState();
        }

        internal void ActivateThirdPersonInput()
        {
            thirdPersonInput.ActivateInput();
            gameplayInputManager.cursorLocked = true;
            gameplayInputManager.cursorInputForLook = true;
            gameplayInputManager.ResetCursorState();
        }
    }
}