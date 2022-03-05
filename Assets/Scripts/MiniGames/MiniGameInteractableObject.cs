using InteractionSystem;
using UnityEngine;

namespace MiniGames
{
    public class MiniGameInteractableObject : BaseInteractableObject
    {
        [SerializeField] private BaseMiniGameController baseMiniGameController;
        [SerializeField] private QueuedMiniGame_SO queuedMiniGame;
        
        protected internal override void Interact()
        {
            queuedMiniGame.miniGameController = baseMiniGameController;
            base.Interact();
        }
    }
}