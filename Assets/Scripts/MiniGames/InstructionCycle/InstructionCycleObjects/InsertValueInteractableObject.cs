using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class InsertValueInteractableObject : BaseInteractableObject
    {
        [SerializeField] private HeldValue_SO heldValue;
        [SerializeField] private InsertableRegister register;

        protected internal override void Interact()
        {
            register.SetStoredValue(heldValue.GetHeldValue());
            base.Interact();
        }
    }
}