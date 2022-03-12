using System;
using System.Collections.Generic;
using DataStructures.Events;
using DataStructures.Variables;
using UnityEngine;

namespace Environment
{
    public class EnvironmentSpaces : MonoBehaviour
    {
        [SerializeField] internal List<EnvironmentSpace> spaces;
        [SerializeField] internal IntVariable currentSpace;

        [SerializeField] private GameEvent onStartDialogue;
        [SerializeField] private GameEvent onEndDialogue;

        [SerializeField] private GameEvent onEndSpaceTransition;

        private void OnEnable()
        {
            foreach (EnvironmentSpace space in spaces)
            {
                space.gameObject.SetActive(false);
            }

            OpenCurrentSpace();
        }

        internal void ChangeSpace(EnvironmentSpace space)
        {
            CloseCurrentSpace();
            currentSpace.value = spaces.IndexOf(space);
            OpenCurrentSpace();
            onEndSpaceTransition.Raise();
        }

        private void CloseCurrentSpace()
        {
            spaces[currentSpace.value].gameObject.SetActive(false);
            if (spaces[currentSpace.value].GetType() == typeof(ThirdPersonEnvironmentSpace))
            {
                ((ThirdPersonEnvironmentSpace) spaces[currentSpace.value]).DeactivateThirdPersonInput();
                onStartDialogue.UnregisterListener(((ThirdPersonEnvironmentSpace)spaces[currentSpace.value]).DeactivateThirdPersonInput);
                onEndDialogue.UnregisterListener(((ThirdPersonEnvironmentSpace)spaces[currentSpace.value]).ActivateThirdPersonInput);
            }
        }

        private void OpenCurrentSpace()
        {
            spaces[currentSpace.value].gameObject.SetActive(true);
            if (spaces[currentSpace.value].GetType() == typeof(ThirdPersonEnvironmentSpace))
            {
                ((ThirdPersonEnvironmentSpace) spaces[currentSpace.value]).ActivateThirdPersonInput();
                onStartDialogue.RegisterListener(((ThirdPersonEnvironmentSpace)spaces[currentSpace.value]).DeactivateThirdPersonInput);
                onEndDialogue.RegisterListener(((ThirdPersonEnvironmentSpace)spaces[currentSpace.value]).ActivateThirdPersonInput);
            }
        }
    }
}