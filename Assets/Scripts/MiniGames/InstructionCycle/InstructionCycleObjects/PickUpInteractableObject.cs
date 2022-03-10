using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class PickUpInteractableObject : BaseInteractableObject
    {
        [SerializeField] private HeldValue_SO heldValue;
        [SerializeField] private Register register;

        protected internal override void Interact()
        {
            heldValue.SetHeldValue((TransportableValue)register.storedValueObject.GetValue());
            base.Interact();
        }
    }
}