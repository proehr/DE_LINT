using System.Collections.Generic;
using DataStructures.Events;
using DataStructures.Variables;
using UnityEngine;

namespace Story
{
    public class StoryController : MonoBehaviour
    {
        [SerializeField] private List<BaseStoryEventObject> storyEvents = new List<BaseStoryEventObject>();
        [SerializeField] private IntVariable currentStoryStage;

        private void OnEnable()
        {
            if (currentStoryStage.value < storyEvents.Count)
            {
                LoadCurrentStory();
            }
        }

        private void NextStory()
        {
            storyEvents[currentStoryStage.value].onEndStoryEvent.UnregisterListener(NextStory);
            currentStoryStage.value++;
            if (currentStoryStage.value < storyEvents.Count)
            {
                LoadCurrentStory();
            }
        }

        private void LoadCurrentStory()
        {
            storyEvents[currentStoryStage.value].onEndStoryEvent.RegisterListener(NextStory);
            storyEvents[currentStoryStage.value].InitializeStoryEvent();
            foreach (GameEvent gameEvent in storyEvents[currentStoryStage.value].onStartStoryEvents)
            {
                gameEvent.Raise();
            }
        }
    }
}