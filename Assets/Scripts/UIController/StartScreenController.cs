using System;
using DataStructures.Events;
using UnityEngine;

namespace UIController
{
    [ExecuteInEditMode]
    public class StartScreenController : MonoBehaviour
    {
        
        [SerializeField] private GameEvent onEnterLoadGameUI;
        [SerializeField] private GameEvent onBackToDefaultUI;
        [SerializeField] private GameObject defaultUI;
        [SerializeField] private GameObject loadGameUI;

        private void Awake()
        {
            onEnterLoadGameUI.RegisterListener(EnterLoadGameUI);
            onBackToDefaultUI.RegisterListener(BackToDefaultUI);
            defaultUI.SetActive(true);
            loadGameUI.SetActive(false);
        }
        
        private void OnEnable()
        {
            onEnterLoadGameUI.RegisterListener(EnterLoadGameUI);
            onBackToDefaultUI.RegisterListener(BackToDefaultUI);
            defaultUI.SetActive(true);
            loadGameUI.SetActive(false);
        }

        private void OnDisable()
        {
            onEnterLoadGameUI.UnregisterListener(EnterLoadGameUI);
            onBackToDefaultUI.UnregisterListener(BackToDefaultUI);
            defaultUI.SetActive(false);
            loadGameUI.SetActive(false);
        }

        private void EnterLoadGameUI()
        {
            defaultUI.SetActive(false);
            loadGameUI.SetActive(true);
        }
        
        private void BackToDefaultUI()
        {
            defaultUI.SetActive(true);
            loadGameUI.SetActive(false);
        }
    }
}