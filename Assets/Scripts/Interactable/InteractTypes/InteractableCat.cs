using UnityEngine;

public class InteractableCat : MonoBehaviour, IInteractable
{
    [SerializeField] private string messageText = "You pet the cat";

    public void Interact()
    {
        ServiceHub.Instance.UiManager.ShowMessage(messageText);
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
