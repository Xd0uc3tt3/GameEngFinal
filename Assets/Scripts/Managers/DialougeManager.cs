using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences = new Queue<string>();

    private UiManager uiManager;
    private PlayerController playerController;

    private void Start()
    {
        uiManager = ServiceHub.Instance.UiManager;
        playerController = ServiceHub.Instance.playerController;
    }

    public void StartDialogue(string[] lines)
    {
        if (lines == null || lines.Length == 0)
        {
            return;
        }

        sentences.Clear();

        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }

        uiManager.ShowDialoguePanel();
        uiManager.ShowInteractionPrompt(false);
        DisplayNext();

        LockPlayer();
    }

    public void DisplayNext()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        UpdateDialogueText(sentence);
    }

    private void UpdateDialogueText(string text)
    {
        var field = typeof(UiManager).GetField("dialogueText", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        TMP_Text dialogueText = (TMP_Text)field.GetValue(uiManager);

        if (dialogueText != null)
        {
            dialogueText.text = text;
        }
    }

    private void EndDialogue()
    {
        uiManager.HideDialoguePanel();
        UnlockPlayer();
    }

    private void LockPlayer()
    {
        playerController.SetMovementEnabled(false);
    }

    private void UnlockPlayer()
    {
        playerController.SetMovementEnabled(true);
    }
}
