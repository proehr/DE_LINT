using System;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public abstract class BaseValue : ScriptableObject
    {
        [SerializeField] internal int value;
        [SerializeField] internal String valueName;

        internal abstract Color GetColor();
    }
}