using DataStructures.Events;
using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class ProgramCounter : Register
    {
        [SerializeField] private BaseInteractableObject incrementValueInteraction;
        [SerializeField] private GameEvent onIncrementCounter;
        [SerializeField] private GameEvent onInsertInstruction;

        internal override void InitializeRegister()
        {
            DeactivateIncrementation();
            onIncrementCounter.RegisterListener(DeactivateIncrementation);
            onInsertInstruction.RegisterListener(ActivateIncrementation);
            base.InitializeRegister();
        }

        private void ActivateIncrementation()
        {
            incrementValueInteraction.gameObject.SetActive(true);
        }

        private void DeactivateIncrementation()
        {
            incrementValueInteraction.gameObject.SetActive(false);
        }
    }
}