using System.Collections.Generic;
using System.Linq;
using DataStructures.Events;
using TMPro;
using UnityEngine;
using Random = System.Random;

namespace MiniGames.PlugAPC
{
    public class PlugAPCController : MonoBehaviour
    {
        [SerializeField] private PlugAPCComponent motherboardPrefab;
        [SerializeField] private List<PlugAPCComponent> componentPrefabs;
        [SerializeField] private TMP_Dropdown componentNameDropdown;
        [SerializeField] private TMP_Dropdown componentFunctionDropdown;
        [SerializeField] private GameEvent onDropdownChange;
        [SerializeField] private TMP_Text infoBox;
        [SerializeField] private RotatorView rotatorView;
        [SerializeField] private GameObject motherboardView;
        [SerializeField] private GameObject leftHalfGameplayView;
        [SerializeField] private GameObject leftHalfEndMinigameView;

        private PlugAPCComponent currentComponent;
        private int currentComponentNumber;
        private List<PlugAPCComponent> randomizedComponentList;
        private Random rng = new Random();

        private void OnEnable()
        {
            motherboardView.SetActive(false);
            ShowGameplayScreen();

            InitializeDropdownOptions();
            RandomizeComponentList();

            onDropdownChange.RegisterListener(CheckDropdownValuesForMotherBoard);

            currentComponentNumber = 0;
            ShowNewComponent(currentComponentNumber);
        }
        
        private void ShowNewComponent(int i)
        {
            currentComponent = Instantiate(randomizedComponentList[i], transform);
            rotatorView.rotator = currentComponent.gameObject;
            infoBox.text = "Pick the correct name and function for this component";
        }
        
        private void NextComponent()
        {
            if (currentComponent != null)
            {
                Destroy(currentComponent.gameObject);
                if (currentComponent.OnPressComponentButton != null)
                {
                    currentComponent.OnPressComponentButton.UnregisterListener(PlaceComponentOnMotherboard);
                    currentComponent.OnPressComponentButton.UnregisterListener(NextComponent);
                }
            }
            currentComponentNumber++;
            if (currentComponentNumber < randomizedComponentList.Count)
            {
                ShowNewComponent(currentComponentNumber);
            }
            else
            {
                ShowEndScreen();
            }
        }

        private void InitializeDropdownOptions()
        {
            componentNameDropdown.options.Add(new TMP_Dropdown.OptionData(motherboardPrefab.ComponentName));
            componentFunctionDropdown.options.Add(new TMP_Dropdown.OptionData(motherboardPrefab.Function));
            foreach (PlugAPCComponent component in componentPrefabs)
            {
                componentNameDropdown.options.Add(new TMP_Dropdown.OptionData(component.ComponentName));
                componentFunctionDropdown.options.Add(new TMP_Dropdown.OptionData(component.Function));
            }
            componentNameDropdown.options = componentNameDropdown.options.OrderBy(a => rng.Next()).ToList();
            componentFunctionDropdown.options = componentFunctionDropdown.options.OrderBy(a => rng.Next()).ToList();
        }

        private void RandomizeComponentList()
        {
            randomizedComponentList = new List<PlugAPCComponent>();
            randomizedComponentList.Add(motherboardPrefab);
            randomizedComponentList.AddRange(componentPrefabs.OrderBy(a => rng.Next()));
        }

        private void CheckDropdownValuesForMotherBoard()
        {
            if (componentNameDropdown.options[componentNameDropdown.value].text == currentComponent.ComponentName &&
                  componentFunctionDropdown.options[componentFunctionDropdown.value].text == currentComponent.Function)
            {
                motherboardView.SetActive(true);
                onDropdownChange.UnregisterListener(CheckDropdownValuesForMotherBoard);
                onDropdownChange.RegisterListener(CheckDropdownValues);
                NextComponent();
            }
        }

        private void CheckDropdownValues()
        {
            if (componentNameDropdown.options[componentNameDropdown.value].text == currentComponent.ComponentName &&
                componentFunctionDropdown.options[componentFunctionDropdown.value].text == currentComponent.Function)
            {
                infoBox.text = "Great! Now pick a location on the motherboard for this component";
                currentComponent.OnPressComponentButton.RegisterListener(PlaceComponentOnMotherboard);
                currentComponent.OnPressComponentButton.RegisterListener(NextComponent);
            }
        }

        private void PlaceComponentOnMotherboard()
        {
            Instantiate(currentComponent.MotherboardViewPrefab, motherboardView.transform);
        }
        
        
        private void ShowEndScreen()
        {
            leftHalfGameplayView.SetActive(false);
            leftHalfEndMinigameView.SetActive(true);
        }

        private void ShowGameplayScreen()
        {
            leftHalfGameplayView.SetActive(true);
            leftHalfEndMinigameView.SetActive(false);
        }
    }
}