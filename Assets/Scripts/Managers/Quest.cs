using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;

    public QuestManager.QuestState currentState = QuestManager.QuestState.NotStarted;

    public string[] requiredItems;
    public string craftedItem;
}
