using System;
using DataStructures.Events;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractableObjectCollider : MonoBehaviour
    {
        [SerializeField] private InteractableObjects_SO interactableObjects;
        [SerializeField] private BaseInteractableObject interactableObject;

        private void Awake()
        {
            interactableObjects.Remove(interactableObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                interactableObjects.Add(interactableObject);
            }
        }

        private void OnDisable()
        {
            if (interactableObjects.IOList.Contains(interactableObject))
            {
                interactableObjects.Remove(interactableObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                interactableObjects.Remove(interactableObject);
            }
        }
    }
}