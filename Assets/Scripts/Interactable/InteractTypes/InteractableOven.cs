using UnityEngine;

public class InteractableOven : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        var questManager = ServiceHub.Instance.QuestManager;
        var quest = questManager.ActiveQuest;
        if (quest == null)
        {
            return;
        }

        int index = questManager.activeQuestIndex;
        questManager.CheckIfCraftable(index);

        if (quest.currentState == QuestManager.QuestState.Craftable)
        {
            questManager.CraftActiveQuest();
            ServiceHub.Instance.UiManager.ShowMessage($"You made {quest.craftedItem}!");
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
