using DataStructures.Events;
using InteractionSystem;
using UnityEngine;

namespace Dialogue
{
    public class DialogueInteractableObject : BaseInteractableObject
    {
        [SerializeField] private DialogueMessage_SO entryDialogueMessage;

        protected internal override void Interact()
        {
            DialogueController.currentDialogueStep = entryDialogueMessage;
            base.Interact();
        }
    }
}