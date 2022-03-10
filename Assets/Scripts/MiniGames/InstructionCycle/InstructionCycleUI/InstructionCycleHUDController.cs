using System;
using DataStructures.Events;
using TMPro;
using UIController;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.InstructionCycle.InstructionCycleUI
{
    public class InstructionCycleHUDController : HUDController
    {
        [SerializeField] private TMP_Text taskText;
        
        [SerializeField] private HeldValue_SO heldValue;
        [SerializeField] private GameEvent onChangeHeldValue;
        [SerializeField] private TMP_Text heldValueText;
        [SerializeField] private Image heldValueBackground;

        protected override void InitializeHUDController()
        {
            onChangeHeldValue.RegisterListener(SetHeldValueInfo);
            base.InitializeHUDController();
        }

        private void SetHeldValueInfo()
        {
            if (heldValue.GetHeldValue() != null)
            {
                heldValueText.text = heldValue.GetHeldValue().valueName;
                heldValueBackground.color = heldValue.GetHeldValue().GetColor();
            }
            else
            {
                heldValueText.text = "Nothing";
                heldValueBackground.color = Color.white;
            }
        }

        internal void SetTaskText(String text)
        {
            taskText.text = text;
        }
    }
}