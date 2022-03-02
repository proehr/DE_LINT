using System;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueOption", menuName = "Dialogue/DialogueOption", order = 0)]
    public class DialogueOption_SO : ScriptableObject
    {
        [SerializeField] private string dialogueOptionText;
        [SerializeField] private BaseDialogueStep_SO nextDialogueStep;

        internal string DialogueOptionText => dialogueOptionText;

        internal void QueueNextDialogueMessage()
        {
            DialogueController.currentDialogueStep = nextDialogueStep;
        }
    }
}