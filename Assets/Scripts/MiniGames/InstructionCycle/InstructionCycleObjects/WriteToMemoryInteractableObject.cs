using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class WriteToMemoryInteractableObject : BaseInteractableObject
    {
        [SerializeField] private HeldValue_SO heldValue;
        [SerializeField] private MemoryBus memoryBus;
        
        protected internal override void Interact()
        {
            memoryBus.WriteValue(heldValue.GetHeldValue());
            base.Interact();
        }
    }
}