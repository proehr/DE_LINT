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

        private void Awake()
        {
            onFinishInstructionCycleGame.RegisterListener(BackToExplorationSpace);
        }

        private void BackToExplorationSpace()
        {
            environmentSpaces.ChangeSpace(explorationSpace);
        }
    }
}