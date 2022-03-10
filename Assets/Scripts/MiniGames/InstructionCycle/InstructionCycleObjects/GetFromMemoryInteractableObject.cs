using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class GetFromMemoryInteractableObject : BaseInteractableObject
    {
        [SerializeField] private HeldValue_SO heldValue;
        [SerializeField] private MemoryBus memoryBus;

        protected internal override void Interact()
        {
            heldValue.SetHeldValue(memoryBus.GetFromMemory((MemoryAddress)heldValue.GetHeldValue()));
            base.Interact();
        }
    }
}