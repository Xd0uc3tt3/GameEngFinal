using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public enum QuestState
    {
        NotStarted,
        InProgress,
        Craftable,
        Crafted,
        Completed
    }

    public QuestState currentState = QuestState.NotStarted;

    public string[] requiredItems = { "Strawberry" };
    public string craftedItem = "Jam";

    public void StartQuest()
    {
        currentState = QuestState.InProgress;
    }

    public void CheckIfCraftable()
    {
        if (currentState != QuestState.InProgress)
        {
            return;
        }

        foreach (var item in requiredItems)
        {
            if (HotbarManager.Instance.GetItemCount(item) <= 0)
            {
                return;
            }  
        }

        currentState = QuestState.Craftable;
    }

    public void CompleteQuest()
    {
        currentState = QuestState.Completed;
    }
}
