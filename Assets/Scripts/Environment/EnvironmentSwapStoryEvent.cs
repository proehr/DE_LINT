using Story;
using UnityEngine;

namespace Environment
{
    public class EnvironmentSwapStoryEvent : BaseStoryEventObject
    {
        [SerializeField] private EnvironmentSpace targetEnvironmentSpace;
        [SerializeField] private EnvironmentSpaces environmentSpaces;

        internal override void InitializeStoryEvent()
        {
            environmentSpaces.ChangeSpace(targetEnvironmentSpace);
        }
    }
}