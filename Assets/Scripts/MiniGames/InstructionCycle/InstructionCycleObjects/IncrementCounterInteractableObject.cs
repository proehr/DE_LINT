using InteractionSystem;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class IncrementCounterInteractableObject : BaseInteractableObject
    {
        [SerializeField] private Register register;
        [SerializeField] private MemoryBus memoryBus;

        protected internal override void Interact()
        {
            BaseValue memoryAddress = ScriptableObject.CreateInstance<MemoryAddress>();
            memoryAddress.value = memoryBus.GetNextInstructionAddressValue(register.storedValueObject.GetValue().value);
            memoryAddress.valueName = "Memory Address" + memoryAddress.value;
            register.storedValueObject.SetValue(memoryAddress);
            base.Interact();
        }
    }
}