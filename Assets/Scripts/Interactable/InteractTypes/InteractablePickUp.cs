using UnityEngine;

public class InteractablePickUp : MonoBehaviour, IInteractable
{
    [SerializeField] private string pickupName = "Fruit";
    [SerializeField] private string messageText = "You picked up a Fruit!";

    public void Interact()
    {
        ServiceHub.Instance.UiManager.ShowMessage(messageText);

        Debug.Log($"Picked up {pickupName}");
        Destroy(gameObject, 0.1f);
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

