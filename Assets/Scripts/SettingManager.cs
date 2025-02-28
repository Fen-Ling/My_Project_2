using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        Settings_Data settings = SettingsDataManager.LoadSettings();

        Screen.SetResolution(settings.width, settings.height, settings.isFullScreen);

        AudioListener.volume = settings.volume;

        Screen.fullScreen = settings.isFullScreen;
    }
}