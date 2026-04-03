using UnityEngine;

public class InteractableDispenser : MonoBehaviour, IInteractable
{
    [SerializeField] private string messageText = "You milked the cow";
    [SerializeField] private string ItemName = "Milk";

    public void Interact()
    {
        HotbarManager.Instance.AddItem(ItemName);
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
