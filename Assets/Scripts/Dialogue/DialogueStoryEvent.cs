using DataStructures.Events;
using Story;
using UnityEngine;

namespace Dialogue
{
    public class DialogueStoryEvent : BaseStoryEventObject
    {

        [SerializeField] private DialogueMessage_SO initialDialogueMessage;

        internal override void InitializeStoryEvent()
        {
            DialogueController.currentDialogueStep = initialDialogueMessage;
        }
        
    }
}