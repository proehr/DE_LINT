using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    [CreateAssetMenu(fileName = "InstructionName", menuName = "InstructionCycle/InstructionName", order = 0)]
    public class InstructionName : BaseValue
    {
        internal override Color GetColor()
        {
            return Color.grey;
        }
    }
}