using System;
using System.Collections.Generic;
using DataStructures.Events;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueMessage", menuName = "Dialogue/DialogueMessage", order = 0)]
    public class DialogueMessage_SO : BaseDialogueStep_SO
    {
        [SerializeField] private String message;
        [SerializeField] private DialogueCharacter_SO dialogueCharacter;
        [SerializeField] private List<DialogueOption_SO> dialogueOptions = new List<DialogueOption_SO>();

        internal string Message => message;

        internal DialogueCharacter_SO DialogueCharacter => dialogueCharacter;

        internal List<DialogueOption_SO> DialogueOptions => dialogueOptions;

    }
}