using DataStructures.Events;
using MiniGames.InstructionCycle.InstructionCycleObjects;
using UnityEngine;

namespace MiniGames.InstructionCycle
{
    [CreateAssetMenu(fileName = "HeldValue", menuName = "InstructionCycle/HeldValue", order = 0)]
    public class HeldValue_SO : ScriptableObject
    {
        [SerializeField] private TransportableValue value;
        [SerializeField] private GameEvent onChangeHeldValue;
        [SerializeField] private GameEvent onPickUpValue;
        [SerializeField] private GameEvent onDropValue;
        [SerializeField] private GameEvent onPickUpMemoryAddress;
        [SerializeField] private GameEvent onDropMemoryAddress;
        [SerializeField] private GameEvent onPickUpInstruction;
        [SerializeField] private GameEvent onDropInstruction;

        public void SetHeldValue(TransportableValue v)
        {
            if (value == null && v != null)
            {
                onPickUpValue.Raise();
            }
            if (!(value is MemoryAddress) && v is MemoryAddress)
            {
                onPickUpMemoryAddress.Raise();
            }
            else if (value is MemoryAddress && !(v is MemoryAddress))
            {
                onDropMemoryAddress.Raise();
            }
            if (!(value is Instruction) && v is Instruction)
            {
                onPickUpInstruction.Raise();
            }
            else if (value is Instruction && !(v is Instruction))
            {
                onDropInstruction.Raise();
            }
            this.value = v;
            onChangeHeldValue.Raise();
        }
        
        public TransportableValue GetHeldValue()
        {
            return value;
        }

        public void DropHeldValue()
        {
            if (value != null)
            {
                onDropValue.Raise();
            }
            if (value is MemoryAddress)
            {
                onDropMemoryAddress.Raise();
            }
            if (value is Instruction)
            {
                onDropInstruction.Raise();
            }
            value = null;
            onChangeHeldValue.Raise();
        }
    }
}