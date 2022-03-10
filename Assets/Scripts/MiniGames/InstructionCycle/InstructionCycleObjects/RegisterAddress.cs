using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    [CreateAssetMenu(fileName = "RegisterAddress", menuName = "InstructionCycle/RegisterAddress", order = 0)]
    public class RegisterAddress : BaseValue
    {
        internal override Color GetColor()
        {
            return Color.cyan;
        }
    }
}