using DataStructures.Events;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueEvent", menuName = "Dialogue/DialogueEvent", order = 0)]
    public class DialogueEvent_SO : BaseDialogueStep_SO
    {
        [SerializeField] private GameEvent dialogueEvent;

        internal GameEvent DialogueEvent => dialogueEvent;
    }
}