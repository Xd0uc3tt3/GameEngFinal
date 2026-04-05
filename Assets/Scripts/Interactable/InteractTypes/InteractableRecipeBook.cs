using UnityEngine;
using System.Text;

public class InteractableRecipeBook : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        var questManager = ServiceHub.Instance.QuestManager;
        var quest = questManager.ActiveQuest;

        if (quest == null)
        {
            ServiceHub.Instance.UiManager.ShowMessage("No active order.");
            return;
        }

        StringBuilder message = new StringBuilder();

        message.AppendLine($"{quest.questName}");
        message.AppendLine("Ingredients:");

        foreach (var item in quest.requiredItems)
        {
            int count = HotbarManager.Instance.GetItemCount(item);
            string status = count > 0 ? "[X]" : "[ ]";
            message.AppendLine($"- {item} {status}");
        }

        message.AppendLine($"\nReward: {quest.craftedItem}");

        ServiceHub.Instance.UiManager.ShowMessage(message.ToString());
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
