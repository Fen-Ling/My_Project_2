using UnityEngine;

public class SettingsState : MonoBehaviour
{
    public GameObject SettingsUI;
    public MainMenuState MainMenu;

    private void OnEnable()
    {
        SettingsUI.SetActive(true);
    }

    private void OnDisable()
    {
        SettingsUI.SetActive(false);
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
}
