using UnityEngine;

public class InteractableNPC1 : MonoBehaviour, IInteractable
{
    [SerializeField] private string[] notStartedDialogue = { "Can you make me some Jam?" };
    [SerializeField] private string[] inProgressDialogue = { "Find some Strawberries." };
    [SerializeField] private string[] craftableDialogue = { "Use the oven to bake it." };
    [SerializeField] private string[] completedDialogue = { "Thank you!" };
    [SerializeField] private string[] questCompleteDialogue = { "Quest Complete!" };

    public void Interact()
    {
        var quest = ServiceHub.Instance.QuestManager;
        string[] linesToShow = null;

        quest.CheckIfCraftable();

        switch (quest.currentState)
        {
            case QuestManager.QuestState.NotStarted:
                quest.StartQuest();
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
                HotbarManager.Instance.RemoveItem("Jam");
                quest.CompleteQuest();
                break;

            case QuestManager.QuestState.Completed:
                linesToShow = questCompleteDialogue;
                break;
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