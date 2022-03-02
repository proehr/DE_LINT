using System;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "NPC", menuName = "Dialogue/NPC", order = 0)]
    public class DialogueCharacter_SO : ScriptableObject
    {
        [SerializeField] private String characterName;
        [SerializeField] private Texture characterImage;

        internal string CharacterName => characterName;

        internal Texture CharacterImage => characterImage;
    }
}