using InteractionSystem;
using UnityEngine;

namespace Environment
{
    public class EnvironmentSwapInteractableObject : BaseInteractableObject
    {
        [SerializeField] private EnvironmentSpaces environmentSpaces;
        [SerializeField] private EnvironmentSpace targetEnvironmentSpace;

        protected internal override void Interact()
        {
            environmentSpaces.ChangeSpace(targetEnvironmentSpace);
            base.Interact();
        }
    }
}