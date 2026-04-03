using UnityEngine;

public class InteractableDialouge : MonoBehaviour, IInteractable
{
    [TextArea(3, 10)]
    public string[] dialogueLines;

    public void Interact()
    {
        if (dialogueLines == null || dialogueLines.Length == 0)
        {
            return;
        }

        DialougeManager dialogueManager = ServiceHub.Instance.DialogueManager;
        dialogueManager.StartDialogue(dialogueLines);
    }

    public void OnFocus()
    {
        ServiceHub.Instance.UiManager.ShowInteractionPrompt(true);
    }

    public void OnUnfocus()
    {
        ServiceHub.Instance.UiManager.ShowInteractionPrompt(false);
    }
}
