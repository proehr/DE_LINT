using System;
using DataStructures.Events;
using UnityEngine;

namespace MiniGames.PlugAPC
{
    public class PlugAPCComponent : MonoBehaviour
    {
        [SerializeField] private String componentName;
        [SerializeField] private String function;
        [SerializeField] private GameObject motherboardViewPrefab;
        [SerializeField] private GameEvent onPressComponentButton;

        internal string ComponentName => componentName;

        internal string Function => function;

        public GameObject MotherboardViewPrefab => motherboardViewPrefab;

        public GameEvent OnPressComponentButton => onPressComponentButton;
    }
}