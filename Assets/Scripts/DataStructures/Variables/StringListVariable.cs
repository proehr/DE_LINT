using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructures.Variables
{
    [Serializable]
    [CreateAssetMenu(fileName = "StringList", menuName = "Data/Variables/StringListVariable", order = 0)]
    public class StringListVariable : AbstractVariable<List<String>>
    {
        
    }
}