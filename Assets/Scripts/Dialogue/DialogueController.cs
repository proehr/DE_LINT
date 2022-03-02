using DataStructures.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        internal static BaseDialogueStep_SO currentDialogueStep;

        [SerializeField] private RawImage dialogCharacterImage;
        [SerializeField] private TMP_Text dialogCharacterName;

        [SerializeField] private TMP_Text dialogueMessage;
        [SerializeField] private RectTransform optionButtonsList;
        
        [SerializeField] private Button optionButtonPrefab;

        private void OnEnable()
        {
            StartNextDialogueStep();
        }

        private void StartNextDialogueStep()
        {
            if (currentDialogueStep.GetType() == typeof(DialogueMessage_SO))
            {
                DialogueMessage_SO message = (DialogueMessage_SO) currentDialogueStep;
                dialogCharacterImage.texture = message.DialogueCharacter.CharacterImage;
                dialogCharacterName.text = message.DialogueCharacter.CharacterName;

                dialogueMessage.text = message.Message;

                for (int i = 0; i < optionButtonsList.childCount; i++)
                {
                    Destroy(optionButtonsList.GetChild(i).gameObject);
                }

                foreach (DialogueOption_SO dialogueOption in message.DialogueOptions)
                {
                    Button optionButton = Instantiate(optionButtonPrefab, optionButtonsList);
                    optionButton.onClick.AddListener(dialogueOption.QueueNextDialogueMessage);
                    optionButton.onClick.AddListener(StartNextDialogueStep);
                    optionButton.GetComponentInChildren<TMP_Text>().text = dialogueOption.DialogueOptionText;
                }
            }
            else if (currentDialogueStep.GetType() == typeof(DialogueEvent_SO))
            {
                DialogueEvent_SO dialogueEvent = (DialogueEvent_SO)currentDialogueStep;
                dialogueEvent.DialogueEvent.Raise();
                
            }
        }
    }
}