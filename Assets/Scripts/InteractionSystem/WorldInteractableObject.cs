using UnityEngine;

namespace InteractionSystem
{
    public class WorldInteractableObject : BaseInteractableObject
    {
        protected internal override void Interact()
        {
            transform.position += Vector3.up;
        }
    }
}