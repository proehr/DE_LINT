using UnityEngine;

namespace Environment
{
    public class EnvironmentSwapButton : MonoBehaviour
    {
        [SerializeField] private EnvironmentSpaces environmentSpaces;
        [SerializeField] private EnvironmentSpace targetEnvironmentSpace;

        public void Swap()
        {
            environmentSpaces.ChangeSpace(targetEnvironmentSpace);
        }
    }
}