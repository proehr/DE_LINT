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
        }
        
        private void OnEnable()
        {
            defaultUI.SetActive(true);
            loadGameUI.SetActive(false);
        }

        private void OnDisable()
        {
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