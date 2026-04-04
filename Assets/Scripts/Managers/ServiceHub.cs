using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    public PlayerController playerController;
    public LevelManager LevelManager;

    public GameStateManager GameStateManager;
    public UiManager UiManager;

    public DialougeManager DialogueManager;
    public QuestManager QuestManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
}