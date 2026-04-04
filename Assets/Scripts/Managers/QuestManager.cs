using UnityEngine;
using System.Collections.Generic;

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

    public List<Quest> quests = new List<Quest>();

    public int activeQuestIndex = 0;

    public Quest ActiveQuest => (activeQuestIndex >= 0 && activeQuestIndex < quests.Count) ? quests[activeQuestIndex] : null;

    public void StartQuest(int index)
    {
        var quest = GetQuest(index);
        if (quest != null && quest.currentState == QuestState.NotStarted)
        {
            activeQuestIndex = index;
            quest.currentState = QuestState.InProgress;
        }
    }

    public void CheckIfCraftable(int index)
    {
        var quest = GetQuest(index);
        if (quest == null || quest.currentState != QuestState.InProgress) return;

        foreach (var item in quest.requiredItems)
        {
            if (HotbarManager.Instance.GetItemCount(item) <= 0) return;
        }
        quest.currentState = QuestState.Craftable;
    }

    public void CraftActiveQuest()
    {
        var quest = ActiveQuest;
        if (quest == null || quest.currentState != QuestState.Craftable)
        {
            return;
        }
            

        foreach (var item in quest.requiredItems)
        {
            HotbarManager.Instance.RemoveItem(item);
        }
            

        HotbarManager.Instance.AddItem(quest.craftedItem);

        quest.currentState = QuestState.Crafted;
    }

    public Quest GetQuest(int index)
    {
        if (index >= 0 && index < quests.Count)
        {
            return quests[index];
        }
            

        return null;
    }

    public void CompleteQuest(int index)
    {
        var quest = GetQuest(index);
        if (quest == null) return;
        quest.currentState = QuestState.Completed;
        if (index == activeQuestIndex)
        {
            activeQuestIndex++;
        }
    }

    public void UpdateQuestProgress()
    {
        var quest = ActiveQuest;
        if (quest != null && quest.currentState == QuestState.InProgress)
        {
            bool hasAllItems = true;
            foreach (var item in quest.requiredItems)
            {
                if (HotbarManager.Instance.GetItemCount(item) <= 0)
                {
                    hasAllItems = false;
                    break;
                }
            }

            if (hasAllItems)
            {
                quest.currentState = QuestState.Craftable;
            }
                
        }
    }
}