using DataStructures.Events;
using DataStructures.Variables;
using UnityEngine;

namespace LintCollection
{
    [CreateAssetMenu(fileName = "LintInventory", menuName = "GameData/LintInventory", order = 0)]
    public class LintInventory : ScriptableObject
    {
        [SerializeField] private int smallLintMaxValue;
        [SerializeField] private IntVariable smallLintCount;
        [SerializeField] private int normalLintMaxValue;
        [SerializeField] private IntVariable normalLintCount;
        [SerializeField] private int bigLintMaxValue;
        [SerializeField] private IntVariable bigLintCount;
        [SerializeField] private GameEvent onBigLintFull;
        [SerializeField] private GameEvent onLintCountChanged;

        public int SmallLintCount => smallLintCount.value;

        public int NormalLintCount => normalLintCount.value;

        public int BigLintCount => bigLintCount.value;

        public void AddSmallLint(int value)
        {
            smallLintCount.value += value;
            RecalcLintCounts();
            onLintCountChanged.Raise();
            CheckBigLint();
        }

        public void AddNormalLint(int value)
        {
            normalLintCount.value += value;
            RecalcLintCounts();
            onLintCountChanged.Raise();
        }

        public void AddBigLint(int value)
        {
            bigLintCount.value += value;
            RecalcLintCounts();
            onLintCountChanged.Raise();
        }

        private void RecalcLintCounts()
        {
            if (smallLintCount.value >= smallLintMaxValue)
            {
                smallLintCount.value = 0;
                normalLintCount.value += 1;
            }

            if (normalLintCount.value >= normalLintMaxValue)
            {
                normalLintCount.value = 0;
                bigLintCount.value += 1;
            }
        }
        
        private void CheckBigLint()
        {
            if (bigLintCount.value >= bigLintMaxValue)
            {
                onBigLintFull.Raise();
            }
        }
    }
}