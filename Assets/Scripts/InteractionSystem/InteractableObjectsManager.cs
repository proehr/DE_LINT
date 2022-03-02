using DataStructures.Events;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractableObjectsManager : MonoBehaviour
    {
        [SerializeField] private GameEvent onScrollUp;
        [SerializeField] private GameEvent onScrollDown;
        [SerializeField] private GameEvent onInteract;
        [SerializeField] private InteractableObjects_SO interactableObjects;

        private void Awake()
        {
            interactableObjects.Reset();
            
            onScrollUp.RegisterListener(interactableObjects.ShiftRight);
            onScrollDown.RegisterListener(interactableObjects.ShiftLeft);
            onInteract.RegisterListener(Interact);
        }

        private void Interact()
        {
            if (interactableObjects.IOList.Count > 0)
            {
                interactableObjects.IOList[0].Interact();
            }
        }
    }
}