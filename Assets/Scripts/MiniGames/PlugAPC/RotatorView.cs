using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiniGames.PlugAPC
{
    public class RotatorView : MonoBehaviour, IDragHandler
    {
        [SerializeField] internal GameObject rotator;
        
        private Vector3 rotation;

        public void OnDrag(PointerEventData eventData)
        {
            rotation.y = -(eventData.delta.x + eventData.delta.y);
            rotator.transform.Rotate(rotation);
        }
    }
}