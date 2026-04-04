using UnityEngine;

public class InteractableNPC1 : MonoBehaviour, IInteractable
{
    [SerializeField] private string[] notStartedDialogue = { "Can you make me some Jam?" };
    [SerializeField] private string[] inProgressDialogue = { "Find some Strawberries." };
    [SerializeField] private string[] craftableDialogue = { "Use the oven to bake it." };
    [SerializeField] private string[] completedDialogue = { "Thank you!" };
    [SerializeField] private string[] questCompleteDialogue = { "Quest Complete!" };

    [SerializeField] private int questIndex;

    public void Interact()
    {
        var questManager = ServiceHub.Instance.QuestManager;
        var quest = questManager.GetQuest(questIndex);
        if (quest == null) return;

        string[] linesToShow = null;

        if (quest.currentState == QuestManager.QuestState.Crafted &&
            HotbarManager.Instance.GetItemCount(quest.craftedItem) > 0)
        {
            HotbarManager.Instance.RemoveItem(quest.craftedItem);
            questManager.CompleteQuest(questIndex);
            linesToShow = questCompleteDialogue;
        }
        else
        {
            questManager.CheckIfCraftable(questIndex);
            switch (quest.currentState)
            {
                case QuestManager.QuestState.NotStarted:
                    questManager.StartQuest(questIndex);
                    linesToShow = notStartedDialogue;
                    break;
                case QuestManager.QuestState.InProgress:
                    linesToShow = inProgressDialogue;
                    break;
                case QuestManager.QuestState.Craftable:
                    linesToShow = craftableDialogue;
                    break;
                case QuestManager.QuestState.Crafted:
                    linesToShow = completedDialogue;
                    break;
                case QuestManager.QuestState.Completed:
                    linesToShow = questCompleteDialogue;
                    break;
            }
        }

        if (linesToShow != null && linesToShow.Length > 0)
        {
            ServiceHub.Instance.DialogueManager.StartDialogue(linesToShow);
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