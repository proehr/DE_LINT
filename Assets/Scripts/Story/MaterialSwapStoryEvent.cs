using System;
using UnityEngine;

namespace Story
{
    public class MaterialSwapStoryEvent : BaseStoryEventObject
    {
        [SerializeField] private Material originalMaterial;
        [SerializeField] private Material targetMaterial;
        [SerializeField] private MeshRenderer meshRenderer;
        
        internal override void InitializeStoryEvent()
        {
            meshRenderer.material = targetMaterial;
            onEndStoryEvent.Raise();
        }

        private void OnDisable()
        {
            meshRenderer.material = originalMaterial;
        }
    }
}