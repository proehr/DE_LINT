using System;
using System.Collections.Generic;
using DataStructures.Events;
using UnityEngine;

namespace Environment.IntroSceneEnvironment
{
    public class IntroSceneController : MonoBehaviour
    {
        [SerializeField] private GameEvent onShowCPUGPU;
        [SerializeField] private GameEvent onShowPrimaryStorage;
        [SerializeField] private GameEvent onShowSecondaryStorage;

        [SerializeField] private GameObject cpu;
        [SerializeField] private GameObject gpu;
        [SerializeField] private GameObject ram;
        [SerializeField] private GameObject ssd;
        [SerializeField] private GameObject hdd;

        private List<GameObject> currentlyActive = new List<GameObject>();

        private void Awake()
        {
            onShowCPUGPU.RegisterListener(ShowCPUGPU);
            onShowPrimaryStorage.RegisterListener(ShowPrimaryStorage);
            onShowSecondaryStorage.RegisterListener(ShowSecondaryStorage);
        }

        private void ShowCPUGPU()
        {
            HideCurrentObjects();
            cpu.SetActive(true);
            currentlyActive.Add(cpu);
            gpu.SetActive(true);
            currentlyActive.Add(gpu);
        }


        private void ShowPrimaryStorage()
        {
            HideCurrentObjects();
            ram.SetActive(true);
            currentlyActive.Add(ram);
        }


        private void ShowSecondaryStorage()
        {
            HideCurrentObjects();
            ssd.SetActive(true);
            currentlyActive.Add(ssd);
            hdd.SetActive(true);
            currentlyActive.Add(hdd);
        }

        private void HideCurrentObjects()
        {
            foreach (GameObject o in currentlyActive)
            {
                o.SetActive(false);
            }

            currentlyActive = new List<GameObject>();
        }
    }
}