using UnityEngine;

public class Settings_Start : MonoBehaviour
{
    public GameObject SettingsUI;
    public Main_Menu MainMenu;

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
