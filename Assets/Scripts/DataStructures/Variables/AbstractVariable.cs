using UnityEngine;

namespace DataStructures.Variables
{
    [CreateAssetMenu(fileName = "AbstractVariable", menuName = "Data/Variables/AbstractVariable", order = 0)]
    public class AbstractVariable<T> : ScriptableObject
    {
        public T value;
    }
}