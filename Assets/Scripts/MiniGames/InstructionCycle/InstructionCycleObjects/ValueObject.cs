using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class ValueObject : MonoBehaviour
    {
        [SerializeField] internal BaseValue value;

        [SerializeField] private TMP_Text text;
        [SerializeField] private Image valueObjectBackground;

        private BaseValue originalValue;

        private void Awake()
        {
            originalValue = value;
            SetTextAndBackground();
        }

        internal void SetValue(BaseValue v)
        {
            this.value = v;
            SetTextAndBackground();
        }

        private void SetTextAndBackground()
        {
            if (value != null)
            {
                text.text = value.valueName;
                valueObjectBackground.color = value.GetColor();
            }
            else
            {
                text.text = "";
                valueObjectBackground.color = Color.white;
            }
        }

        internal BaseValue GetValue()
        {
            return value;
        }

        internal void ResetValueObject()
        {
            SetValue(originalValue);
        }
    }
}