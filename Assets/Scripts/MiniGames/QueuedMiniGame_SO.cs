using UnityEngine;

namespace MiniGames
{
    [CreateAssetMenu(fileName = "QueuedMiniGame", menuName = "MiniGames/QueuedMiniGame", order = 0)]
    public class QueuedMiniGame_SO : ScriptableObject
    {
        public BaseMiniGameController miniGameController;
    }
}