using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused,
    Settings,
    Credits

}

public class GameStateManager : MonoBehaviour
{
    private UiManager uiManager;
    private PlayerInput inputActions;

    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }

    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Awake()
    {
        inputActions = new PlayerInput();
    }

    private void Start()
    {
        uiManager = ServiceHub.Instance.UiManager;
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState)
        {
            return;
        }

        previousState = currentState;
        currentState = newState;

        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        switch (newState)
        {
            case GameState.Init:
                Debug.Log("GameState Changed to Init");
                SetState(GameState.MainMenu);
                break;

            case GameState.MainMenu:
                Debug.Log("GameState Changed to MainMenu");
                Time.timeScale = 0f;
                uiManager.ShowMainMenuUI();
                break;

            case GameState.Gameplay:
                Debug.Log("GameState Changed to GamePlay");
                Time.timeScale = 1f;
                uiManager.ShowGameplayUI();
                break;

            case GameState.Paused:
                Debug.Log("GameState Changed to Paused");
                Time.timeScale = 0f;
                uiManager.ShowPausedUI();
                break;

            case GameState.Settings:
                Debug.Log("GameState Changed to Settings");
                Time.timeScale = 0f;
                uiManager.ShowSettingsUI();
                break;

            case GameState.Credits:
                Debug.Log("GameState Changed to Credits");
                Time.timeScale = 0f;
                uiManager.ShowCreditsUI();
                break;

            default:
                break;


        }
    }

    public void GoToGameplay()
    {
        SetState(GameState.Gameplay);
    }

    public void OpenSettings()
    {
        SetState(GameState.Settings);
    }

    public void CloseSettings()
    {
        SetState(previousState);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Pause.performed += OnPausePressed;
    }

    private void OnDisable()
    {
        inputActions.Player.Pause.performed -= OnPausePressed;
        inputActions.Disable();
    }

    private void OnPausePressed(InputAction.CallbackContext context)
    {
        Debug.Log("Pause pressed!");
        TogglePause();
    }

    public void TogglePause()
    {
        if (currentState == GameState.Gameplay)
        {
            SetState(GameState.Paused);
        }
        else if (currentState == GameState.Paused)
        {
            SetState(GameState.Gameplay);
        }
    }

    public void GoToMainMenu()
    {
        SetState(GameState.MainMenu);
    }

    public void GoToCredits()
    {
        SetState(GameState.Credits);
    }

    public void CloseCredits()
    {
        SetState(previousState);
    }
}