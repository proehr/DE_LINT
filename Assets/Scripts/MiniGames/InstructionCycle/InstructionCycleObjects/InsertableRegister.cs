using DataStructures.Events;
using UnityEngine;

namespace MiniGames.InstructionCycle.InstructionCycleObjects
{
    public class InsertableRegister : Register
    {
        [SerializeField] internal InsertValueInteractableObject insertValueInteraction;
        [SerializeField] internal GameEvent onPickUpValue;
        [SerializeField] internal GameEvent onDropValue;

        internal override void InitializeRegister()
        {
            DisableInsertInteraction();
            onPickUpValue.RegisterListener(EnableInsertInteraction);
            onDropValue.RegisterListener(DisableInsertInteraction);
            base.InitializeRegister();
        }


        internal virtual void EnableInsertInteraction()
        {
            insertValueInteraction.gameObject.SetActive(true);
        }

        internal virtual void DisableInsertInteraction()
        {
            insertValueInteraction.gameObject.SetActive(false);
        }
    }
}