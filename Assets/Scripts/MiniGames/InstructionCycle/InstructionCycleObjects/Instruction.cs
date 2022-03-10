using System;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    [CreateAssetMenu(fileName = "Instruction", menuName = "InstructionCycle/Instruction", order = 0)]
    public class Instruction : TransportableValue
    {
        public InstructionName instructionName;
        public BaseValue parameterOne;
        public BaseValue parameterTwo;
        public String instructionDescription;
        public InstructionType type;

        public BaseValue GetTransportableValue()
        { 
            if (parameterOne is TransportableValue)
            {
                return parameterOne;
            }
            if (parameterTwo is TransportableValue)
            {
                return parameterTwo;
            }

            return null;
        }

        internal override Color GetColor()
        {
            return Color.magenta;
        }
    }
}