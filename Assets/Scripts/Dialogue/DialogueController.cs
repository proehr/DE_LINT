using System.Linq;
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

        [SerializeField] private GameEvent onStartDialogue;
        [SerializeField] private GameEvent onEndDialogue;
        [SerializeField] private GameObject dialogueCanvas;

        private void OnEnable()
        {
            onStartDialogue.RegisterListener(OpenDialogueCanvas);
            onEndDialogue.RegisterListener(CloseDialogueCanvas);
        }

        private void OpenDialogueCanvas()
        {
            dialogueCanvas.SetActive(true);
            StartNextDialogueStep();
        }

        private void CloseDialogueCanvas()
        {
            dialogueCanvas.SetActive(false);
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

                foreach (GameEvent loadImageEvent in message.LoadImageEvents)
                {
                    loadImageEvent.Raise();
                }
            }
            else if (currentDialogueStep.GetType() == typeof(DialogueEvent_SO))
            {
                DialogueEvent_SO dialogueEvent = (DialogueEvent_SO)currentDialogueStep;
                foreach (GameEvent gameEvent in dialogueEvent.DialogueEvents)
                {
                    gameEvent.Raise();
                }
            }
        }
    }
}