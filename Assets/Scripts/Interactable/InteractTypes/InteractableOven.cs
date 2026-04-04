using UnityEngine;

public class InteractableOven : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        var quest = ServiceHub.Instance.QuestManager;

        quest.CheckIfCraftable();

        if (quest.currentState == QuestManager.QuestState.Craftable)
        {
            foreach (var item in quest.requiredItems)
            {
                HotbarManager.Instance.RemoveItem(item);
            }
                

            HotbarManager.Instance.AddItem(quest.craftedItem);

            quest.currentState = QuestManager.QuestState.Crafted;

            ServiceHub.Instance.UiManager.ShowMessage("You made some Jam!");
        }
        else
        {
            ServiceHub.Instance.UiManager.ShowMessage("You don't have the ingredients.");
        }
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
