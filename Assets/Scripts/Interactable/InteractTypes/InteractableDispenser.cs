using UnityEngine;

public class InteractableDispenser : MonoBehaviour, IInteractable
{
    [SerializeField] private string messageText = "You milked the cow";
    [SerializeField] private string ItemName = "Milk";

    private bool hasBeenShaken = false;

    public void Interact()
    {
        if (hasBeenShaken)
        {
            messageText = "You cannot milk this cow";
            ServiceHub.Instance.UiManager.ShowMessage(messageText);
            return;
        }

        hasBeenShaken = true;

        bool added = HotbarManager.Instance.AddItem(ItemName);

        if (added)
        {
            ServiceHub.Instance.UiManager.ShowMessage(messageText);
        }
    }

    public void OnFocus()
    {
        if (hasBeenShaken)
        {
            return;
        }

        ServiceHub.Instance.UiManager.ShowInteractionPrompt(true);
    }

    public void OnUnfocus()
    {
        ServiceHub.Instance.UiManager.ShowInteractionPrompt(false);
    }
}
