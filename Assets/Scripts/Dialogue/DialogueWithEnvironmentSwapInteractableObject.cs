using DataStructures.Events;
using Environment;
using InteractionSystem;
using UnityEngine;

namespace Dialogue
{
    public class DialogueWithEnvironmentSwapInteractableObject : BaseInteractableObject
    {
        [SerializeField] private DialogueMessage_SO entryDialogueMessage;
        [SerializeField] private GameEvent onEndDialogue;
        [SerializeField] private EnvironmentSpaces environmentSpaces;
        [SerializeField] private EnvironmentSpace targetEnvironmentSpace;

        protected internal override void Interact()
        {
            DialogueController.currentDialogueStep = entryDialogueMessage;
            onEndDialogue.RegisterListener(ChangeSpace);
            base.Interact();
        }

        private void ChangeSpace()
        {
            onEndDialogue.UnregisterListener(ChangeSpace);
            environmentSpaces.ChangeSpace(targetEnvironmentSpace);
        }
    }
}