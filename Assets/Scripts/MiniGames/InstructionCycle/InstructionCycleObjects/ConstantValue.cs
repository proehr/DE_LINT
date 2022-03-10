using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    [CreateAssetMenu(fileName = "ConstantValue", menuName = "InstructionCycle/ConstantValue", order = 0)]
    public class ConstantValue : TransportableValue
    {
        internal override Color GetColor()
        {
            return Color.green;
        }
    }
}