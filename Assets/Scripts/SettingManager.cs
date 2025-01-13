using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        Settings_Data settings = SettingsDataManager.LoadSettings();

        Screen.SetResolution(settings.width, settings.height, settings.isFullScreen);

        audioSource.volume = settings.volume;

        Screen.fullScreen = settings.isFullScreen;

        
    }
}