using UnityEngine;

public class Settings_State : MonoBehaviour
{
    public GameObject SettingsUI;
    public Pause_Menu PauseMenu;

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
        PauseMenu.gameObject.SetActive(true);
    }
}
