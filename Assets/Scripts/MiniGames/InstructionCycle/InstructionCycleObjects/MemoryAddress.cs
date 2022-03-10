using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    [CreateAssetMenu(fileName = "MemoryAddress", menuName = "InstructionCycle/MemoryAddress", order = 0)]
    public class MemoryAddress : TransportableValue
    {
        internal override Color GetColor()
        {
            return Color.red;
        }
    }
}