using DataStructures.Events;
using UnityEngine;

namespace UIController
{
    public class PauseScreenController : MonoBehaviour
    {
        
        [SerializeField] private GameEvent onEnterOptionsUI;
        [SerializeField] private GameEvent onExitOptionsUI;
        
        [SerializeField] private GameObject defaultUI;
        [SerializeField] private GameObject optionsUI;
        
        private void Awake()
        {
            onEnterOptionsUI.RegisterListener(EnterOptionsUI);
            onExitOptionsUI.RegisterListener(ExitOptionsUI);
        }
        
        private void OnEnable()
        {
            defaultUI.SetActive(true);
            optionsUI.SetActive(false);
        }

        private void OnDisable()
        {
            defaultUI.SetActive(false);
            optionsUI.SetActive(false);
        }

        private void EnterOptionsUI()
        {
            defaultUI.SetActive(false);
            optionsUI.SetActive(true);
        }
        
        private void ExitOptionsUI()
        {
            defaultUI.SetActive(true);
            optionsUI.SetActive(false);
        }
    }
}