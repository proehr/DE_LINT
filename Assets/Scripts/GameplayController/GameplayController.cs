using System;
using DataStructures.Events;
using Environment;
using UnityEngine;

namespace GameplayController
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private GameEvent onFinishInstructionCycleGame;
        [SerializeField] private EnvironmentSpaces environmentSpaces;
        [SerializeField] private EnvironmentSpace explorationSpace;
        [SerializeField] private GameObject dialogueController;
        [SerializeField] private GameObject storyController;

        private void OnEnable()
        {
            onFinishInstructionCycleGame.RegisterListener(BackToExplorationSpace);
            dialogueController.SetActive(true);
            environmentSpaces.gameObject.SetActive(true);
            storyController.SetActive(true);
        }

        private void OnDisable()
        {
            onFinishInstructionCycleGame.RegisterListener(BackToExplorationSpace);
            dialogueController.SetActive(false);
            environmentSpaces.gameObject.SetActive(false);
            storyController.SetActive(false);
        }

        private void BackToExplorationSpace()
        {
            environmentSpaces.ChangeSpace(explorationSpace);
        }
    }
}