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
        [SerializeField] private GameEvent onPickUpMemoryAddress;
        [SerializeField] private GameEvent onDropMemoryAddress;

        public void SetHeldValue(TransportableValue v)
        {
            if (!(value is MemoryAddress) && v is MemoryAddress)
            {
                onPickUpMemoryAddress.Raise();
            }
            else if (value is MemoryAddress && !(v is MemoryAddress))
            {
                onDropMemoryAddress.Raise();
            }
            this.value = v;
            onPickUpValue.Raise();
            onChangeHeldValue.Raise();
        }
        
        public TransportableValue GetHeldValue()
        {
            return value;
        }

        public void DropHeldValue()
        {
            if (value is MemoryAddress)
            {
                onDropMemoryAddress.Raise();
            }
            value = null;
            onChangeHeldValue.Raise();
        }
    }
}