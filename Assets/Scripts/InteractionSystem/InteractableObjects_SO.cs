using System.Collections.Generic;
using DataStructures.Events;
using UnityEngine;

namespace InteractionSystem
{
    [CreateAssetMenu(fileName = "InteractableObjects", menuName = "InteractionSystem/InteractableObjects", order = 0)]
    public class InteractableObjects_SO : ScriptableObject
    {

        [SerializeField] private GameEvent onChangeInteractableObjects;
        
        private List<BaseInteractableObject> ioList = new List<BaseInteractableObject>();
        public List<BaseInteractableObject> IOList => ioList;

        internal void Add(BaseInteractableObject interactableObject)
        {
            ioList.Add(interactableObject);
            onChangeInteractableObjects.Raise();
        }

        internal void Remove(BaseInteractableObject interactableObject)
        {
            ioList.Remove(interactableObject);
            onChangeInteractableObjects.Raise();
        }
        
        public void ShiftLeft()
        {
            if (ioList.Count > 1)
            {
                BaseInteractableObject io = ioList[0];
                ioList.Remove(io);
                ioList.Add(io);
                onChangeInteractableObjects.Raise();
            }
        }
        
        public void ShiftRight()
        {
            if (ioList.Count > 1)
            {
                BaseInteractableObject io = ioList[ioList.Count-1];
                ioList.Remove(io);
                ioList.Insert(0, io);
                onChangeInteractableObjects.Raise();
            }
        }

        public void Reset()
        {
           ioList = new List<BaseInteractableObject>();
        }
    }
}