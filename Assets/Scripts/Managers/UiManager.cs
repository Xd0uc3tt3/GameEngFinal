using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject CreditsUI;

    public void ShowMainMenuUI()
    {
        HideAllUI();

        MainMenuUI.SetActive(true);
    }

    public void ShowGameplayUI()
    {
        HideAllUI();

        gameplayUI.SetActive(true);
    }

    public void ShowPausedUI()
    {
        HideAllUI();

        pausedUI.SetActive(true);
    }

    public void ShowSettingsUI()
    {
        HideAllUI();

        SettingsUI.SetActive(true);
    }

    public void ShowCreditsUI()
    {
        HideAllUI();

        CreditsUI.SetActive(true);
    }

    public void HideAllUI()
    {
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(false);
        CreditsUI.SetActive(false);
    }

}
