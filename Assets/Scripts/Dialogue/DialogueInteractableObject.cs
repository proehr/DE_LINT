using DataStructures.Events;
using InteractionSystem;
using UnityEngine;

namespace Dialogue
{
    public class DialogueInteractableObject : BaseInteractableObject
    {
        [SerializeField] private DialogueMessage_SO entryDialogueMessage;
        [SerializeField] private GameEvent onStartDialogue;

        protected internal override void Interact()
        {
            DialogueController.currentDialogueStep = entryDialogueMessage;
            onStartDialogue.Raise();
        }
    }
}