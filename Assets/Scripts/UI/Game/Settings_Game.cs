using UnityEngine;

public class Settings_Game : MonoBehaviour
{
    public GameObject SettingsUI;
    public Pause_Menu PauseMenu;

    private void OnEnable()
    {
        SettingsUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        SettingsUI.SetActive(false);
    }

    public void BackToMenu()
    {
        gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
    }
}
